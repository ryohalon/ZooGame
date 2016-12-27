using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class FadeIn2 : MonoBehaviour
{
    [SerializeField]
    private GameObject balloon2 = null;
    private Timer timer = null;
    public bool isFadeInEnd = false;
    private float fadeTime = 0.0f;
    public float fadeTakeTime = 1.0f;
    public float fadeDelayTime = 0.0f;

    void Awake()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    void Start()
    {
        int childEndIndex = transform.parent.childCount - 1;
        transform.SetSiblingIndex(childEndIndex);

        if (timer.isBalloonUp)
        {

            var balloon2_ = Instantiate(balloon2);
            balloon2_.transform.SetParent(transform.parent);
            balloon2_.transform.localScale = Vector3.one;

            var balloon2__ = Instantiate(balloon2);
            balloon2__.transform.SetParent(transform.parent);
            balloon2__.transform.localScale = Vector3.one;
            var balloonUpper = balloon2__.GetComponent<BalloonUpper2>();
            balloonUpper.start_pos = new Vector2(400.0f, 0.0f);
            balloonUpper.end_pos = new Vector2(-300.0f, 700.0f);

            StartCoroutine(UpdateFadeIn());
        }
        else
        {
            isFadeInEnd = true;
            GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
        }
    }

    private IEnumerator UpdateFadeIn()
    {
        while (true)
        {
            fadeTime += Time.deltaTime;
            var easing = GetComponent<Easing>();
            float alpha = easing.CubicIn(easing.DelayTime(fadeTime, fadeDelayTime, fadeTakeTime), 1.0f, 0.0f);
            if (alpha <= 0.0f)
            {
                isFadeInEnd = true;
                timer.isBalloonUp = false;
                transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
            }

            Color color = new Color(1.0f, 1.0f, 1.0f, alpha);
            GetComponent<Image>().color = color;

            yield return null;
        }
    }
}
