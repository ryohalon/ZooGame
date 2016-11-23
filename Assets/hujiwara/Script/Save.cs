using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class Save : MonoBehaviour
{
    string savePath;
    string file;

    void Start()
    {
        savePath = Application.persistentDataPath + "/";
        file = "test.csv";
    }

    public void Saver()
    {
        LineCSVSave(1, 0, savePath, file);
    }

    public void Writer(string data, string directory, string path)
    {
        using (var stream = new FileStream(directory + path, FileMode.OpenOrCreate))
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(data);
            }
        }
    }

    public void MapSaver()
    {
        List<List<int>> map = new List<List<int>>();
        for(int i = 0; i < 6; ++i)
        {
            List<int> line = new List<int>();
            line.Add(i + 1);
            line.Add(0);
            map.Add(line);
        }
        ItemMapCSVSave(map, savePath, file);
    }

    // (テスト)2次元配列セーブ
    void ItemMapCSVSave(List<List<int>> data, string directory, string path)
    {
        string save = string.Empty;
        for(int i = 0; i < data.Count - 1; ++i)
        {
            save += LineCSVMaker(data[i]);
            save += "\n";
        }
        save += LineCSVMaker(data[data.Count - 1]);

        Writer(save, directory, path);
    }
    // 上の関数で使ってます
    string LineCSVMaker(List<int> data)
    {
        string csv = string.Empty;

        for(int i = 0; i < data.Count - 1; ++i)
        {
            csv += data[i].ToString();
            csv += ",";
        }
        csv += data[data.Count - 1].ToString();

        return csv;
    }

    // (テスト)一行分
    void LineCSVSave(int id, int num, string directory, string path)
    {
        string save = string.Empty;
        save += id.ToString();
        save += ",";
        save += num.ToString();

        Writer(save, directory, path);
    }

    public void FoodStatusClassSave()
    {
        List<FoodStatus> statuses = new List<FoodStatus>();
        statuses.Add(new FoodStatus(0, 0));
        statuses.Add(new FoodStatus(1, 0));
        statuses.Add(new FoodStatus(2, 0));
        statuses.Add(new FoodStatus(3, 0));
        statuses.Add(new FoodStatus(4, 0));
        statuses.Add(new FoodStatus(5, 0));
        FoodStatusCSVSave(statuses, savePath, file);
    }

    void FoodStatusCSVSave(List<FoodStatus> data, string directory, string path)
    {
        string save = string.Empty;

        for(int i = 0; i < data.Count - 1; ++i)
        {
            save += data[i].CSV;
            save += "\n";
        }
        save += data[data.Count - 1].CSV;

        Writer(save, directory, path);
    }

    class FoodStatus
    {
        int ID;
        int possession;

        public FoodStatus() { }

        public FoodStatus(int ID, int possession)
        {
            this.ID = ID;
            this.possession = possession;
        }

        public string CSV
        {
            get
            {
                string csv = string.Empty;
                csv += ID.ToString();
                csv += ",";
                csv += possession.ToString();
                return csv;
            }
        }
    }
}