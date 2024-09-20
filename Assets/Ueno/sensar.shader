Shader "Custom/sensar"
{
    Properties
    {
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
        [PerRendererData] _EmitTex("Emit Texture", 2D) = "black" {}
        _Color("Tint", Color) = (1,1,1,1)
        [HDR] _EmitColor("Emit Color", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha("Enable External Alpha", Float) = 0
    }

        SubShader
        {
            Tags
            {
                "Queue" = "Transparent"
                "IgnoreProjector" = "True"
                "RenderType" = "Transparent"
                "PreviewType" = "Plane"
                "CanUseSpriteAtlas" = "True"
            }

            Cull Off
            Lighting Off
            ZWrite Off
            Blend One OneMinusSrcAlpha

            Pass
            {
            CGPROGRAM
                #pragma vertex SpriteVertEx
                #pragma fragment SpriteFragEx
                #pragma target 2.0
                #pragma multi_compile_instancing
                #pragma multi_compile_local _ PIXELSNAP_ON
                #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
                #include "UnitySprites.cginc"

    sampler2D _EmitTex;
    fixed4 _EmitColor;

    v2f SpriteVertEx(appdata_t IN)
    {
        v2f OUT;

        UNITY_SETUP_INSTANCE_ID(IN);
        UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

        OUT.vertex = UnityFlipSprite(IN.vertex, _Flip);
        OUT.vertex = UnityObjectToClipPos(OUT.vertex);
        OUT.texcoord = IN.texcoord;
        OUT.color = IN.color * _RendererColor;

        #ifdef PIXELSNAP_ON
        OUT.vertex = UnityPixelSnap(OUT.vertex);
        #endif

        return OUT;
    }

    fixed4 SpriteFragEx(v2f IN) : SV_Target
    {
        float2 uv = IN.texcoord;
        fixed4 texCol = tex2D(_MainTex, uv);
        clip(texCol.a - 0.001);
        fixed4 emCol = tex2D(_EmitTex, uv);
        fixed4 color = (emCol.r * emCol.a > 0) ? _EmitColor * (emCol.r) : texCol * _Color;

        #if ETC1_EXTERNAL_ALPHA
        fixed4 alpha = tex2D(_AlphaTex, uv);
        color.a = lerp(color.a, alpha.r, _EnableExternalAlpha);
        #endif

        return color;
    }

            ENDCG
            }

        }
}