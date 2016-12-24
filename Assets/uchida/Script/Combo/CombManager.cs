using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class CombManager : MonoBehaviour
{
    public List<List<int>> comboList = new List<List<int>>();
    public List<float> comboRateList = new List<float>();

    public float totalComboRate = 1.0f;

    private CombManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            LoadCombo();
            LoadComboRate();
        }
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void LoadComboRate()
    {
        FileInfo comboRateFile = new FileInfo(Application.dataPath + "/uchida/resource/Text/comboRate.csv");
        try
        {
            using (StreamReader sr = new StreamReader(comboRateFile.Open(FileMode.Open, FileAccess.Read)))
            {
                string txt = sr.ReadToEnd();

                string[] comboRate = txt.Split(',');
                foreach(var comboRate_ in comboRate)
                {
                    if (comboRate_ == "\n")
                        continue;

                    comboRateList.Add(float.Parse(comboRate_) / 100.0f);
                }

                sr.Close();
            }
        }
        catch(Exception e)
        {

        }
    }

    private void LoadCombo()
    {
        FileInfo comboFile = new FileInfo(Application.dataPath + "/uchida/resource/Text/combo.csv");
        try
        {
            using (StreamReader sr = new StreamReader(comboFile.Open(FileMode.Open, FileAccess.Read)))
            {
                string txt = sr.ReadToEnd();

                string[] combo = txt.Split('\n');
                foreach (var combo_ in combo)
                {
                    string[] com = combo_.Split(',');
                    List<int> comboList_ = new List<int>();
                    foreach (var com_ in com)
                    {
                        comboList_.Add(int.Parse(com_));
                    }

                    comboList.Add(comboList_);
                }

                sr.Close();   
            }
        }
        catch (Exception e)
        {

        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void CheckCombo(int[] idList)
    {
        totalComboRate = 1.0f;

        for (int i = 0; i < comboList.Count; i++)
        {
            int num = 0;

            foreach (var id in idList)
            {
                foreach (var combo in comboList[i])
                {
                    if (id != combo)
                        continue;

                    num++;
                    break;
                }
            }

            if (num < comboList[i].Count)
                continue;

            totalComboRate += comboRateList[i];
        }


        Debug.Log(totalComboRate);
    }
}
