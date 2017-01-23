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
        TextAsset csvFile = Resources.Load("Data/comboRate") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        string line = reader.ReadLine();
        string[] comboRate = line.Split(',');

        foreach(var rate in comboRate)
            comboRateList.Add(float.Parse(rate) / 100.0f);
    }

    private void LoadCombo()
    {
        TextAsset csvFile = Resources.Load("Data/combo") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while(reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] combo = line.Split(',');
            List<int> comboList_ = new List<int>();

            foreach (var combo_ in combo)
                comboList_.Add(int.Parse(combo_));

            comboList.Add(comboList_);
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


        Debug.Log("comb : " + totalComboRate);
    }
}
