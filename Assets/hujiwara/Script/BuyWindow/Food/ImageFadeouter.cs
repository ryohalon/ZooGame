using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageFadeouter : MonoBehaviour
{
    public Text text;
    Text missingText;

    Image image;

    Color imageColor;
    Color textColor;

    bool isShow;

    float time = 2;
    float setTime = 2;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        missingText = text.GetComponent<Text>();

        imageColor = image.color;
        textColor = missingText.color;

        isShow = false;

        InitAlpha();
    }

    public void InitAlpha()
    {
        imageColor.a = 0;
        textColor.a = 0;
        image.color = imageColor;
        missingText.color = textColor;
    }

    void Update()
    {
        if(isShow)
        {
            time -= Time.deltaTime;
            Debug.Log(time);
            if(time <= 0f)
            {
                gameObject.SetActive(false);
                isShow = false;
                imageColor.a = 0;
                textColor.a = 0;
                image.color = imageColor;
                missingText.color = textColor;
            }
        }
    }

    public void Fadeout()
    {
        isShow = true;

        gameObject.SetActive(true);
        time = setTime;

        imageColor.a = 1;
        textColor.a = 1;
        image.color = imageColor;
        missingText.color = textColor;
    }
}