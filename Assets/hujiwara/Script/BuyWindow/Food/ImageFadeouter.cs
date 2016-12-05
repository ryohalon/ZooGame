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

    bool isActive;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        missingText = text.GetComponent<Text>();

        imageColor = image.color;
        textColor = text.color;

        isShow = false;

        isActive = gameObject.activeSelf;

        InitAlpha();
    }

    public void InitAlpha()
    {
        imageColor.a = 0;
        textColor.a = 0;
        image.color = imageColor;
        text.color = textColor;
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
                text.color = textColor;
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
        text.color = textColor;

        

        if(!isShow)
        {
            
        }
    }
}