using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public enum EasingPattern
{
    Linear,

    EaseInSin,
    EaseOutSin,
    EaseInOutSin,

    EaseInQuad,
    EaseOutQuad,
    EaseInOutQuad,

    EaseInCubic,
    EaseOutCubic,
    EaseInOutCubic,

    EaseInQuart,
    EaseOutQuart,
    EaseInOutQuart,

    EaseInQuint,
    EaseOutQuint,
    EaseInOutQuint,

    EaseInExpo,
    EaseOutExpo,
    EaseInOutExpo,

    EaseInCirc,
    EaseOutCirc,
    EaseInOutCirc,

    EaseInBack,
    EaseOutBack,
    EaseInOutBack,

    EaseInBounce,
    EaseOutBounce,
    EaseInOutBounce,

    EaseInElastic,
    EaseOutElastic,
    EaseInOutElastic,

    EaseInZeroOne,
    EaseOutZeroOne,
    EaseInOutZeroOne,
}

public static class Easing
{
    //íËêî
    private const float C1 = 1.70158f;
    private const float C2 = C1 * 1.525f;
    private const float C3 = C1 + 1;
    private const float C4 = (2 * Mathf.PI) / 3f;
    private const float C5 = (2 * Mathf.PI) / 4.5f;
    private const float N1 = 7.5625f;
    private const float D1 = 2.75f;

    //é¿ç€Ç…égÇ§ä÷êî
    public static float Value(float current, float min, float max, EasingPattern ease = EasingPattern.Linear)
    {
        if (current <= min) return 0;
        if (max <= current) return 1;

        var diff = max - min;
        var time = current - min;

        var x = time / diff;
        return ease switch
        {
            EasingPattern.Linear => Linear(x),

            EasingPattern.EaseInSin => EaseInSin(x),
            EasingPattern.EaseOutSin => EaseOutSin(x),
            EasingPattern.EaseInOutSin => EaseInOutSin(x),

            EasingPattern.EaseInQuad => EaseInQuad(x),
            EasingPattern.EaseOutQuad => EaseOutQuad(x),
            EasingPattern.EaseInOutQuad => EaseInOutQuad(x),

            EasingPattern.EaseInCubic => EaseInCubic(x),
            EasingPattern.EaseOutCubic => EaseOutCubic(x),
            EasingPattern.EaseInOutCubic => EaseInOutCubic(x),

            EasingPattern.EaseInQuart => EaseInQuart(x),
            EasingPattern.EaseOutQuart => EaseOutQuart(x),
            EasingPattern.EaseInOutQuart => EaseInOutQuart(x),

            EasingPattern.EaseInQuint => EaseInQuint(x),
            EasingPattern.EaseOutQuint => EaseOutQuint(x),
            EasingPattern.EaseInOutQuint => EaseInOutQuint(x),

            EasingPattern.EaseInExpo => EaseInExpo(x),
            EasingPattern.EaseOutExpo => EaseOutExpo(x),
            EasingPattern.EaseInOutExpo => EaseInOutExpo(x),

            EasingPattern.EaseInCirc => EaseInCirc(x),
            EasingPattern.EaseOutCirc => EaseOutCirc(x),
            EasingPattern.EaseInOutCirc => EaseInOutCirc(x),

            EasingPattern.EaseInBack => EaseInBack(x),
            EasingPattern.EaseOutBack => EaseOutBack(x),
            EasingPattern.EaseInOutBack => EaseInOutBack(x),

            EasingPattern.EaseInBounce => EaseInBounce(x),
            EasingPattern.EaseOutBounce => EaseOutBounce(x),
            EasingPattern.EaseInOutBounce => EaseInOutBounce(x),

            EasingPattern.EaseInZeroOne => EaseInZeroOne(x),
            EasingPattern.EaseOutZeroOne => EaseOutZeroOne(x),
            EasingPattern.EaseInOutZeroOne => EaseInOutZeroOne(x),

            _ => throw new ArgumentOutOfRangeException(nameof(ease), ease, null)
        };
    }

    private static float Linear(float x) => x;

    //EaseSignån
    private static float EaseInSin(float x)
        => 1 - Mathf.Cos((x * Mathf.PI) / 2);

    private static float EaseOutSin(float x)
        => Mathf.Sin((x * Mathf.PI) / 2);

    private static float EaseInOutSin(float x)
        => -(Mathf.Cos(Mathf.PI * x) - 1) / 2;

    //EaseQuadån
    private static float EaseInQuad(float x)
        => x * x;

    private static float EaseOutQuad(float x)
        => 1 - (1 - x) * (1 - x);

    private static float EaseInOutQuad(float x)
        => x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;

    //EaseCubicån
    private static float EaseInCubic(float x)
        => x * x * x;

    private static float EaseOutCubic(float x)
        => 1 - Mathf.Pow(1 - x, 3);

    private static float EaseInOutCubic(float x)
        => x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;

    //EaseQuartån
    private static float EaseInQuart(float x)
        => x * x * x * x;

    private static float EaseOutQuart(float x)
        => 1 - Mathf.Pow(1 - x, 4);

    private static float EaseInOutQuart(float x)
        => x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;

    //EaseQuintån
    private static float EaseInQuint(float x)
        => x * x * x * x * x;

    private static float EaseOutQuint(float x)
        => 1 - Mathf.Pow(1 - x, 5);

    private static float EaseInOutQuint(float x)
        => x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;

    //EaseExpoån
    private static float EaseInExpo(float x)
        => x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10);

    private static float EaseOutExpo(float x)
        => Mathf.Approximately(x, 1) ? 1 : 1 - Mathf.Pow(2, -10 * x);

    private static float EaseInOutExpo(float x)
        => x == 0 ? 0 : Mathf.Approximately(x, 1) ? 1
            : x < 0.5 ? Mathf.Pow(2, 20 * x - 10) / 2 : (2 - Mathf.Pow(2, -20 * x + 10)) / 2;

    //EaseCircån
    private static float EaseInCirc(float x)
        => 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));

    private static float EaseOutCirc(float x)
        => Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));

    private static float EaseInOutCirc(float x)
    {
        return x < 0.5 ?
            (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2 :
            (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;
    }

    //EaseBackån
    private static float EaseInBack(float x)
        => C3 * x * x * x - C1 * x * x;

    private static float EaseOutBack(float x)
        => 1 + C3 * Mathf.Pow(x - 1, 3) + C1 * Mathf.Pow(x - 1, 2);

    private static float EaseInOutBack(float x)
    {
        return x < 0.5 ?
            (Mathf.Pow(2 * x, 2) * ((C2 + 1) * 2 * x - C2)) / 2 :
            (Mathf.Pow(2 * x - 2, 2) * ((C2 + 1) * (x * 2 - 2) + C2) + 2) / 2;
    }

    // //EaseElasticån
    private static float EaseInElastic(float x)
        => x == 0 ? 0 : Mathf.Approximately(x, 1) ? 1
                 : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10f - 10.75f) * C4);

    private static float EaseOutElastic(float x)
        => x == 0 ? 0 : Mathf.Approximately(x, 1) ? 1
                 : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10f - 0.75f) * C4) + 1;

    private static float EaseInOutElastic(float x)
    {
        return x == 0 ? 0 : Mathf.Approximately(x, 1) ? 1 : x < 0.5 ?
            -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * C5)) / 2f :
            (Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * C5)) / 2f + 1f;
    }

    //EaseBounceån
    private static float EaseInBounce(float x)
        => 1 - EaseOutBounce(1 - x);

    private static float EaseOutBounce(float x)
    {
        return x switch
        {
            < 1 / D1 => N1 * x * x,
            < 2 / D1 => N1 * (x -= 1.5f / D1) * x + 0.75f,
            < 2.5f / D1 => N1 * (x -= 2.25f / D1) * x + 0.9375f,
            _ => N1 * (x -= 2.625f / D1) * x + 0.984375f
        };
    }

    private static float EaseInOutBounce(float x)
        => x < 0.5f ? (1 - EaseOutBounce(1 - 2 * x)) / 2f : (1 + EaseOutBounce(2 * x - 1)) / 2f;

    private static float EaseInZeroOne(float x) => 1;

    private static float EaseOutZeroOne(float x) => x < 1 ? 0 : 1;

    private static float EaseInOutZeroOne(float x) => x < 0.5f ? 0 : 1;

    // //Template Easeån
    // public static float EaseIn(this float x) 
    //     => ;
    //
    // public static float EaseOut(this float x) 
    //     => ;
    //
    // public static float EaseInOut(this float x) 
    //     => ;
}

public static class EaseExtension
{
    public static void Ease(ref this float value, float current, float min, float max, float pow = 1
        , EasingPattern ease = EasingPattern.Linear)
    {
        value = Easing.Value(current, min, max, ease) * pow;
    }

    public static void Ease(ref this Vector3 value, float current, float min, float max, float pow = 1
        , EasingPattern ease = EasingPattern.Linear)
    {
        value = Vector3.one * (Easing.Value(current, min, max, ease) * pow);
    }

    public static void EaseScale(this Transform value, float current, float min, float max, float pow = 1
        , EasingPattern ease = EasingPattern.Linear)
    {
        var scale = value.localScale;
        scale.Ease(current, min, max, pow, ease);

        value.localScale = scale;
    }

    public static void EasePosition(this Transform value, float current, float min, float max, float pow = 1
        , EasingPattern ease = EasingPattern.Linear)
    {
        var pos = value.position;
        pos.Ease(current, min, max, pow, ease);

        value.position = pos;
    }
}