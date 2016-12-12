using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimeZoneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas = null;
    private Timer timer = null;
    [SerializeField]
    private Sprite sun = null;
    [SerializeField]
    private Sprite moon = null;
    [SerializeField]
    private Sprite morningScene = null;
    [SerializeField]
    private Sprite nightScene = null;

    private bool isTimeZoneChange = false;
    private bool isEnd = false;

    public float rotateSpeed = 20.0f;

    void Awake()
    {

    }

    void Start()
    {

        timer = GameObject.Find("Timer").GetComponent<Timer>();

        if (timer.NowTime() < 3)
        {
            Sound.PlayBgm("GameMainBgm");
            GetComponent<Image>().sprite = sun;
            canvas.GetComponent<Image>().sprite = morningScene;
        }
            
        else
        {
            Sound.PlayBgm("GameMainNightBgm");
            GetComponent<Image>().sprite = moon;
            canvas.GetComponent<Image>().sprite = nightScene;
            isTimeZoneChange = true;
            isEnd = true;
        }

        StartCoroutine(UpdateTimeZone());
    }

    IEnumerator UpdateTimeZone()
    {
        while (true)
        {
            CheckTime();
            TimeZoneChange();

            if (Input.GetKeyDown(KeyCode.F10))
                isTimeZoneChange = this;

            yield return null;
        }
    }

    private void TimeZoneChange()
    {
        if (!isTimeZoneChange)
            return;
        if (isEnd)
            return;

        transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f);

        if (transform.eulerAngles.y >= 90.0f && transform.eulerAngles.y < 90.0f + rotateSpeed * 1.5f)
        {
            Sound.PlayBgm("GameMainNightBgm");
            canvas.GetComponent<Image>().sprite = nightScene;
            GetComponent<Image>().sprite = moon;
        }
            
        if(transform.eulerAngles.y >= 180.0f)
        {
            transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            isEnd = true;
        }
    }

    private void CheckTime()
    {
        if (timer.NowTime() < 3)
            return;

        var timeZoneSprite = GetComponent<Image>().sprite;
        if (timeZoneSprite == nightScene)
            return;

        isTimeZoneChange = true;
    }
}
