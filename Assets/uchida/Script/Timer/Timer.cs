using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    [System.Serializable]
    public struct Date
    {
        public int year;
        public int month;
        public int day;
        public int hour;
        public int minute;
        public float second;
    }
    public Date startDayDate;
    public Date lastDate;
    public Date nowDate;

    public float timeOfDay = 6.0f;
    public bool isEndDay = false;

    public bool isBalloonUp = true;

    private PlayerStatusManager player = null;

    static private Timer instance = null;

    public void SetStartDayTime()
    {
        startDayDate.year = DateTime.Now.Year;
        startDayDate.month = DateTime.Now.Month;
        startDayDate.day = DateTime.Now.Day;
        startDayDate.hour = DateTime.Now.Hour;
        startDayDate.minute = DateTime.Now.Minute;
        startDayDate.second = DateTime.Now.Second;
        isEndDay = false;
        nowDate.year = DateTime.Now.Year;
        nowDate.month = DateTime.Now.Month;
        nowDate.day = DateTime.Now.Day;
        nowDate.hour = DateTime.Now.Hour;
        nowDate.minute = DateTime.Now.Minute;
        nowDate.second = DateTime.Now.Second;
    }

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            LoadLastApplicationEndTime();
            LoadNowTime();
        }
        if(instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void MoneyEarnedWhenNotActivated()
    {
        if (startDayDate.year == 0)
            return;

        if (IsEndDay())
            isEndDay = true;

        float elapsedTime = Mathf.Abs((float)nowDate.hour - (float)lastDate.hour) * 60.0f * 60.0f
            + (float)(nowDate.minute - lastDate.minute) * 60.0f
            + (nowDate.second - lastDate.second);
        player.GetElapsedTimeVisitors(elapsedTime);
    }

    private bool IsEndDay()
    {
        if (nowDate.year - startDayDate.year > 0)
            return true;
        if (nowDate.month - startDayDate.month > 0)
            return true;
        if (nowDate.day - startDayDate.day > 1)
            return true;
        float elapsedTime = 0.0f;
        if (nowDate.day - startDayDate.day == 1)
        {
            elapsedTime = (float)nowDate.hour
                + 24.0f - (float)startDayDate.hour
                + (float)(nowDate.minute - startDayDate.minute) / 60.0f
                + (nowDate.second - startDayDate.second) / 60.0f / 60.0f;
        }
        if (nowDate.day - startDayDate.day == 0)
        {
            elapsedTime = (float)nowDate.hour - (float)startDayDate.hour
                + (float)(nowDate.minute - startDayDate.minute) / 60.0f
                + (nowDate.second - startDayDate.second) / 60.0f / 60.0f;
        }
        if (elapsedTime >= timeOfDay)
            return true;

        return false;
    }

    private void LoadNowTime()
    {
        nowDate.year = DateTime.Now.Year;
        nowDate.month = DateTime.Now.Month;
        nowDate.day = DateTime.Now.Day;
        nowDate.hour = DateTime.Now.Hour;
        nowDate.minute = DateTime.Now.Minute;
        nowDate.second = DateTime.Now.Second;
    }

    private void LoadLastApplicationEndTime()
    {
        string txt = "";

        FileInfo fi = new FileInfo(Application.dataPath + "/uchida/resource/Text/LastDate.csv");
        try
        {
            using (StreamReader sr = new StreamReader(fi.Open(FileMode.Open, FileAccess.Read)))
            {
                txt += sr.ReadToEnd();

                sr.Close();
            }
        }
        catch (Exception e)
        {

        }

        string[] lastDate_ = txt.Split(',');
        startDayDate.year = int.Parse(lastDate_[0]);
        startDayDate.month = int.Parse(lastDate_[1]);
        startDayDate.day = int.Parse(lastDate_[2]);
        startDayDate.hour = int.Parse(lastDate_[3]);
        startDayDate.minute = int.Parse(lastDate_[4]);
        startDayDate.second = int.Parse(lastDate_[5]);
        lastDate.year = int.Parse(lastDate_[6]);
        lastDate.month = int.Parse(lastDate_[7]);
        lastDate.day = int.Parse(lastDate_[8]);
        lastDate.hour = int.Parse(lastDate_[9]);
        lastDate.minute = int.Parse(lastDate_[10]);
        lastDate.second = float.Parse(lastDate_[11]);
    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerStatusManager>();

        MoneyEarnedWhenNotActivated();

        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            if(!isBalloonUp)
            {
                if(SceneManager.GetActiveScene().ToString() == "Title")
                {
                    isBalloonUp = true;
                }
            }

            if (!isEndDay)
            {
                // Debug
                if (Input.GetKey(KeyCode.A))
                {
                    if (Input.GetKey(KeyCode.B))
                    {
                        if (Input.GetKeyDown(KeyCode.C))
                                isEndDay = true;
                    }
                }

                nowDate.second += Time.deltaTime;
                if (nowDate.second >= 60.0f)
                {
                    nowDate.minute++;
                    nowDate.second -= 60.0f;
                }

                if (nowDate.minute >= 60.0f)
                {
                    nowDate.hour++;
                    nowDate.minute -= 60;
                }
                if (nowDate.hour >= 24)
                {
                    nowDate.day = DateTime.Now.Day;
                    nowDate.month = DateTime.Now.Month;
                    nowDate.year = DateTime.Now.Year;
                    nowDate.hour = DateTime.Now.Hour;
                }

                float elapsedTime = Mathf.Abs((float)nowDate.hour - (float)startDayDate.hour)
                + (float)(nowDate.minute - startDayDate.minute) / 60.0f
                + (nowDate.second - startDayDate.second) / 60.0f / 60.0f;
                if (elapsedTime >= timeOfDay)
                    isEndDay = true;
            }

            yield return null;
        }
    }


    // アプリ終了時に時間を書き込みをしておく
    public void OnApplicationQuit()
    {
        StreamWriter writer;
        writer = new StreamWriter(Application.dataPath + "/uchida/resource/Text/LastDate.csv", false);
        writer.WriteLine(startDayDate.year +
            "," + startDayDate.month +
            "," + startDayDate.day +
            "," + startDayDate.hour +
            "," + startDayDate.minute +
            "," + startDayDate.second +
            "," + DateTime.Now.Year +
            "," + DateTime.Now.Month +
            "," + DateTime.Now.Day +
            "," + DateTime.Now.Hour +
            "," + DateTime.Now.Minute +
            "," + DateTime.Now.Second +
            ",");
        writer.Flush();
        writer.Close();
    }

    public int NowTime()
    {
        int nowTime = (int)(Mathf.Abs((float)nowDate.hour - (float)startDayDate.hour)
                + (float)(nowDate.minute - startDayDate.minute) / 60.0f
                + (nowDate.second - startDayDate.second) / 60.0f / 60.0f);

        return nowTime;
    }
}
