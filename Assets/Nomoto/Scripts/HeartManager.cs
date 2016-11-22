using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] heart = null;

    [SerializeField]
    public int MaxValue = 0;

    [SerializeField]
    public int NowValue = 0;


    [SerializeField]
    public Vector2 size = new Vector2(100, 100);

    public void Change(int nowValue, int maxValue)
    {
        MaxValue = maxValue;
        NowValue = nowValue;

        int valueSize = MaxValue / 5;
        int count = 0;
        while (nowValue > valueSize)
        {
            heart[count].SetActive(true);
            ++count;
            nowValue -= valueSize;
        }

        if(nowValue > 0)
        {
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Texture2D texture = Resources.Load<Texture2D>("Heart");
            Debug.Log(texture);
            Sprite sprite = new Sprite();
            Rect rect = new Rect(0.0f, 0.0f, texture.width * ((float)nowValue / (float)valueSize), texture.height);
            sprite = Sprite.Create(texture, rect, pivot, 1f);
            heart[count].SetActive(true);
            heart[count].GetComponent<Image>().sprite = sprite;
            heart[count].GetComponent<RectTransform>().sizeDelta = new Vector2(size.x * ((float)nowValue / (float)valueSize), size.y);
        }


    }

    void Start()
    {
        Change(50, 100);
    }

    void Update()
    {
    }
}
