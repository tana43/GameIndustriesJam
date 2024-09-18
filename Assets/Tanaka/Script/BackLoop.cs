using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackLoop : MonoBehaviour
{
    private const float maxLength_ = 1.0f;
    private const string propName_ = "_MainTex";

    public Vector2 offsetSpeed_;

    [SerializeField]
    private Material material_;

    // Start is called before the first frame update
    void Start()
    {
        //material_ = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        if (material_)
        {
            // xとyの値が0 ～ 1でリピートするようにする
            var x = Mathf.Repeat(Time.time * offsetSpeed_.x, maxLength_);
            var y = Mathf.Repeat(Time.time * offsetSpeed_.y, maxLength_);
            var offset = new Vector2(x, y);
            material_.SetTextureOffset(propName_, offset);
        }
    }

    private void OnDestroy()
    {
        // ゲームをやめた後にマテリアルのOffsetを戻しておく
        if (material_)
        {
            material_.SetTextureOffset(propName_, Vector2.zero);
        }
    }
}
