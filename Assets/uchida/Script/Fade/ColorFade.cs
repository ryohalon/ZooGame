using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorFade : MonoBehaviour
{
    public bool isFadeEnd = false;

    public enum FadeType
    {
        FADEIN,
        FADEOUT
    }
    public FadeType fadeType = FadeType.FADEIN;
    public Color fadeColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    private float time = 0.0f;
    public float takeTime = 1.0f;

    private Easing easing = null;

    void Start()
    {
        easing = GetComponent<Easing>();
    }

    void Update()
    {
        if (isFadeEnd)
            return;

        time += Time.deltaTime;
        float alpha = 1.0f;
        if (fadeType == FadeType.FADEIN)
            alpha = easing.CubicIn(easing.DelayTime(time, 0.0f, takeTime), 1.0f, 0.0f);
        else if(fadeType == FadeType.FADEOUT)
            alpha = easing.CubicIn(easing.DelayTime(time, 0.0f, takeTime), 0.0f, 1.0f);

        GetComponent<Image>().color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);

        if (time >= takeTime)
            isFadeEnd = true;
    }
}
