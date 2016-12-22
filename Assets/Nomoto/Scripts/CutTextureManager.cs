using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CutTextureManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] cutTexture = null;
    public int MaxValue = 0;
    public int NowValue = 0;
    public int BeforeValue;
    public int valueDef;
    public float animationTime = 0.0f;
    public Vector2 size = new Vector2(100, 100);
    [SerializeField]
    Texture2D texture = null;

    bool isAnimaiton = false;

    public void Change(int nowValue, int maxValue)
    {
        MaxValue = maxValue;
        NowValue = nowValue;

        int valueSize = MaxValue / 5;
        int count = 0;
        while (nowValue >= valueSize)
        {
            cutTexture[count].SetActive(true);
            cutTexture[count].GetComponent<RectTransform>().sizeDelta = new Vector2(size.x, size.y);
            Sprite sprite = new Sprite();
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Rect rect = new Rect(0.0f, 0.0f, texture.width, texture.height);
            sprite = Sprite.Create(texture, rect, pivot, 1f);
            cutTexture[count].GetComponent<Image>().sprite = sprite;
            ++count;

            nowValue -= valueSize;
        }

        if (nowValue > 0)
        {
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Debug.Log(texture);
            Sprite sprite = new Sprite();
            Rect rect = new Rect(0.0f, 0.0f, texture.width * ((float)nowValue / (float)valueSize), texture.height);
            sprite = Sprite.Create(texture, rect, pivot, 1f);
            cutTexture[count].SetActive(true);
            cutTexture[count].GetComponent<Image>().sprite = sprite;
            cutTexture[count].GetComponent<RectTransform>().sizeDelta = new Vector2(size.x * ((float)nowValue / (float)valueSize), size.y);
        }


    }

    public void SetAnimation(int beforeValue, int nowValue, int maxValue)
    {
        MaxValue = maxValue;
        NowValue = nowValue;
        BeforeValue = beforeValue;
        if(beforeValue != nowValue)
        isAnimaiton = true;
        valueDef = NowValue - BeforeValue;
    }

    private void Animation()
    {
        if (isAnimaiton == false) return;

        int valueSize = MaxValue / 5;
        int count = 0;
        float nowValue = 0.0f;

        animationTime += Time.deltaTime;

        if (animationTime < 2.0f)
            nowValue = (float)BeforeValue + (float)((float)valueDef * (animationTime / 2.0f));

        else if(animationTime > 2.0f)
        {
            nowValue = NowValue;
            isAnimaiton = false;
            animationTime = 0.0f;
        }
        while (nowValue >= valueSize)
        {
            cutTexture[count].SetActive(true);
            cutTexture[count].GetComponent<RectTransform>().sizeDelta = new Vector2(size.x, size.y);
            Sprite sprite = new Sprite();
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Rect rect = new Rect(0.0f, 0.0f, texture.width, texture.height);
            sprite = Sprite.Create(texture, rect, pivot, 1f);
            cutTexture[count].GetComponent<Image>().sprite = sprite;
            ++count;

            nowValue -= valueSize;
        }

        if (nowValue > 0)
        {
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Debug.Log(texture);
            Sprite sprite = new Sprite();
            Rect rect = new Rect(0.0f, 0.0f, texture.width * (nowValue / (float)valueSize), texture.height);
            sprite = Sprite.Create(texture, rect, pivot, 1f);
            cutTexture[count].SetActive(true);
            cutTexture[count].GetComponent<Image>().sprite = sprite;
            cutTexture[count].GetComponent<RectTransform>().sizeDelta = new Vector2(size.x * (nowValue / (float)valueSize), size.y);
        }
    }

    void Start()
    {
    }

    void Update()
    {
        Animation();
    }
}
