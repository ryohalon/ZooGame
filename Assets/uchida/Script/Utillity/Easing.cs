using UnityEngine;
using System.Collections;

public class Easing : MonoBehaviour
{
    public float DelayTime(float time, float delayTime, float takeTime)
    {
        float t = Mathf.Min(1.0f, Mathf.Max(0.0f, time - delayTime) / takeTime);
        return t;
    }

    public float Linear(float t, float b, float e)
    {
        return (e - b) * t + b;
    }

    public float BackIn(float t, float b, float e)
    {
        float s = 1.70158f;
        return (e - b) * t * t * ((s + 1) * t - s) + b;
    }

    float BackOut(float t, float b, float e)
    {
        float s = 1.70158f;
        t -= 1.0f;
        return (e - b) * (t * t * ((s + 1) * t + s) + 1) + b;
    }

    float BackInOut(float t, float b, float e)
    {
        float s = 1.70158f * 1.525f;
        if ((t /= 0.5f) < 1) return (e - b) / 2 * (t * t * ((s + 1) * t - s)) + b;
        t -= 2;
        return (e - b) / 2 * (t * t * ((s + 1) * t + s) + 2) + b;
    }

    float BounceOut(float t, float b, float e)
    {
        if (t < (1 / 2.75f))
        {
            return (e - b) * (7.5625f * t * t) + b;
        }
        else if (t < (2 / 2.75f))
        {
            t -= (1.5f / 2.75f);
            return (e - b) * (7.5625f * t * t + 0.75f) + b;
        }
        else if (t < (2.5 / 2.75))
        {
            t -= (2.25f / 2.75f);
            return (e - b) * (7.5625f * t * t + 0.9375f) + b;
        }
        else
        {
            t -= (2.625f / 2.75f);
            return (e - b) * (7.5625f * t * t + 0.984375f) + b;
        }
    }

    float BounceIn(float t, float b, float e)
    {
        return (e - b) - BounceOut(1.0f - t, 0.0f, e - b) + b;
    }

    float BounceInOut(float t, float b, float e)
    {
        if (t < 0.5f) return BounceIn(t * 2.0f, 0.0f, e - b) * 0.5f + b;
        else return BounceOut(t * 2.0f - 1.0f, 0.0f, e - b) * 0.5f + (e - b) * 0.5f + b;
    }

    float CircIn(float t, float b, float e)
    {
        return -(e - b) * (Mathf.Sqrt(1 - t * t) - 1) + b;
    }

    float CircOut(float t, float b, float e)
    {
        t -= 1.0f;
        return (e - b) * Mathf.Sqrt(1 - t * t) + b;
    }

    public float CircInOut(float t, float b, float e)
    {
        if ((t /= 0.5f) < 1) return -(e - b) / 2 * (Mathf.Sqrt(1 - t * t) - 1) + b;
        t -= 2;
        return (e - b) / 2 * (Mathf.Sqrt(1 - t * t) + 1) + b;
    }

    public float CubicIn(float t, float b, float e)
    {
        return (e - b) * t * t * t + b;
    }

    public float CubicOut(float t, float b, float e)
    {
        t -= 1.0f;
        return (e - b) * (t * t * t + 1) + b;
    }

    float CubicInOut(float t, float b, float e)
    {
        if ((t /= 0.5f) < 1) return (e - b) / 2 * t * t * t + b;
        t -= 2;
        return (e - b) / 2 * (t * t * t + 2) + b;
    }

    float ElasticIn(float t, float b, float e)
    {
        if (t == 0) return b;
        if (t == 1) return e;

        float p = 0.3f;
        float a = e - b;
        float s = p / 4.0f;
        float pi = Mathf.PI;
        t -= 1.0f;
        return -(a * Mathf.Pow(2.0f, 10.0f * t) * Mathf.Sin((t - s) * (2.0f * pi) / p)) + b;
    }

    float ElasticOut(float t, float b, float e)
    {
        if (t == 0) return b;
        if (t == 1) return e;

        float p = 0.3f;
        float a = e - b;
        float s = p / 4.0f;
        float pi = Mathf.PI;
        return (a * Mathf.Pow(2.0f, -10.0f * t) * Mathf.Sin((t - s) * (2.0f * pi) / p) + a + b);
    }

    float ElasticInOut(float t, float b, float e)
    {
        if (t == 0) return b;
        if ((t /= 0.5f) == 2) return e;

        float p = 0.3f * 1.5f;
        float a = e - b;
        float s = p / 4.0f;
        float pi = Mathf.PI;
        if (t < 1.0f)
        {
            t -= 1.0f;
            return -0.5f * (a * Mathf.Pow(2.0f, 10.0f * t) * Mathf.Sin((t - s) * (2.0f * pi) / p)) + b;
        }
        t -= 1;
        return a * Mathf.Pow(2.0f, -10.0f * t) * Mathf.Sin((t - s) * (2.0f * pi) / p) * 0.5f + a + b;
    }

    public float ExpoIn(float t, float b, float e)
    {
        return (t == 0.0f) ? b : (e - b) * Mathf.Pow(2.0f, 10.0f * (t - 1.0f)) + b;
    }

    public float ExpoOut(float t, float b, float e)
    {
        return (t == 1.0f) ? e : (e - b) * (-Mathf.Pow(2.0f, -10.0f * t) + 1.0f) + b;
    }

    public float ExpoInOut(float t, float b, float e)
    {
        if (t == 0.0f) return b;
        if (t == 1.0f) return e;
        if ((t /= 0.5f) < 1.0f) return (e - b) / 2.0f * Mathf.Pow(2.0f, 10.0f * (t - 1.0f)) + b;
        return (e - b) / 2.0f * (-Mathf.Pow(2.0f, -10.0f * --t) + 2.0f) + b;
    }

    public float QuadIn(float t, float b, float e)
    {
        return (e - b) * t * t + b;
    }

    public float QuadOut(float t, float b, float e)
    {
        return -(e - b) * t * (t - 2.0f) + b;
    }

    public float QuadInOut(float t, float b, float e)
    {
        if ((t /= 0.5f) < 1.0f) return (e - b) / 2.0f * t * t + b;
        --t;
        return -(e - b) / 2.0f * (t * (t - 2.0f) - 1.0f) + b;
    }

    //float QuartIn(float t, float b, float e)
    //{
    //    return (e - b) * t * t * t * t + b;
    //}

    //float QuartOut(float t, float b, float e)
    //{
    //    t -= 1.0;
    //    return -(e - b) * (t * t * t * t - 1) + b;
    //}

    //float QuartInOut(float t, float b, float e)
    //{
    //    if ((t /= 0.5) < 1) return (e - b) / 2 * t * t * t * t + b;
    //    t -= 2;
    //    return -(e - b) / 2 * (t * t * t * t - 2) + b;
    //}

    //float QuintIn(float t, float b, float e)
    //{
    //    return (e - b) * t * t * t * t * t + b;
    //}

    //float QuintOut(float t, float b, float e)
    //{
    //    t -= 1.0;
    //    return (e - b) * (t * t * t * t * t + 1) + b;
    //}

    //float QuintInOut(float t, float b, float e)
    //{
    //    if ((t /= 0.5) < 1) return (e - b) / 2 * t * t * t * t * t + b;
    //    t -= 2;
    //    return (e - b) / 2 * (t * t * t * t * t + 2) + b;
    //}

    //float SineIn(float t, float b, float e)
    //{
    //    return -(e - b) * std::cos(t * (float(M_PI) / 2.f)) + (e - b) + b;
    //}

    //float SineOut(float t, float b, float e)
    //{
    //    return (e - b) * std::sin(t * (float(M_PI) / 2.f)) + b;
    //}

    //float SineInOut(float t, float b, float e)
    //{
    //    return -(e - b) / 2.f * (std::cos(float(M_PI) * t) - 1.f) + b;
    //}
}
