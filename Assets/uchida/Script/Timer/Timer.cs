using UnityEngine;
using System.Collections;
using System.IO;
using System;


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
    public Date lastDate;
    public Date nowDate;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnApplicationQuit()
    {
        StreamWriter writer;
        FileInfo fi;
        fi = new FileInfo(Application.dataPath + "/uchida/resource/Text/LastDate.csv");
        writer = fi.AppendText();
        writer.WriteLine(DateTime.Now.Year +
            ", " + DateTime.Now.Month +
            ", " + DateTime.Now.Day +
            ", " + DateTime.Now.TimeOfDay);
        writer.Flush();
        writer.Close();
    }
}
