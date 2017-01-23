using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class FoodStatus : MonoBehaviour
{
    static private FoodStatus instance = null;

    string directory;
    string path;

    List<List<string>> m_data = new List<List<string>>();
    const char SplitChar = ',';
    string m_commentString = "//";

    public List<FoodStatusManager2> foodList = new List<FoodStatusManager2>();

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Debug.Log(Application.persistentDataPath);

        directory = Application.dataPath + "/" + "hujiwara" + "/";
        path = "FoodStatus.csv";

        if (File.Exists(Application.persistentDataPath + "/" + "FoodStatus.csv"))
        {
            Load(Application.persistentDataPath + "/", "FoodStatus.csv");
        }
        else if (File.Exists(Application.dataPath + "/" + "hujiwara" + "/" + "FoodStatus.csv"))
        {
            Load(Application.dataPath + "/" + "hujiwara" + "/", "FoodStatus.csv");
        }

        Read();
    }

    public void ResetPossession()
    {
        foodList[0].possessionNumber = 10;
        foodList[1].possessionNumber = 10;
        foodList[2].possessionNumber = 10;
        foodList[3].possessionNumber = 10;
        foodList[4].possessionNumber = 10;
        foodList[5].possessionNumber = 10;
        Save();
    }

    public void Read()
    {
        for (int i = 0; i < 6; ++i)
        {
            foodList.Add(new FoodStatusManager2());
        }

        for (int i = 0; i < 6; ++i)
        {
            foodList[i].ID = GetInt(i, 0);
            foodList[i].Name = GetString(i, 1);
            foodList[i].purchasePrice = GetInt(i, 2);
            foodList[i].loveDegreeUpValue = GetFloat(i, 3);
            foodList[i].satietyLevelUpValue = GetFloat(i, 4);
            foodList[i].foodType = GetInt(i, 5);
            foodList[i].possessionNumber = GetInt(i, 6);
        }
    }

    public void Save()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "FoodStatus.csv"))
        {
            using (var stream = new FileStream(Application.persistentDataPath + "/" + "FoodStatus.csv", FileMode.Open))
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    string csv = string.Empty;
                    csv += "//ID" + "," + "//名前" + "," + "//値段" + "," + "//愛情度上昇値" + "," + "//満腹度上昇値" + "," + "//種類" + "," + "//初期所持数";
                    csv += "\n";

                    for (int i = 0; i < 6; ++i)
                    {
                        csv += foodList[i].ID;
                        csv += ",";
                        csv += foodList[i].Name;
                        csv += ",";
                        csv += foodList[i].purchasePrice;
                        csv += ",";
                        csv += foodList[i].loveDegreeUpValue;
                        csv += ",";
                        csv += foodList[i].satietyLevelUpValue;
                        csv += ",";
                        csv += foodList[i].foodType;
                        csv += ",";
                        csv += foodList[i].possessionNumber;
                        csv += "\n";
                    }
                    writer.WriteLine(csv);
                }
            }
        }
        else
        {
            using (var stream = new FileStream(Application.persistentDataPath + "/" + "FoodStatus.csv", FileMode.Create))
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    string csv = string.Empty;
                    csv += "//ID" + "," + "//名前" + "," + "//値段" + "," + "//愛情度上昇値" + "," + "//満腹度上昇値" + "," + "//種類" + "," + "//初期所持数";
                    csv += "\n";
                    for (int i = 0; i < 6; ++i)
                    {
                        csv += foodList[i].ID;
                        csv += ",";
                        csv += foodList[i].Name;
                        csv += ",";
                        csv += foodList[i].purchasePrice;
                        csv += ",";
                        csv += foodList[i].loveDegreeUpValue;
                        csv += ",";
                        csv += foodList[i].satietyLevelUpValue;
                        csv += ",";
                        csv += foodList[i].foodType;
                        csv += ",";
                        csv += foodList[i].possessionNumber;
                        csv += "\n";
                    }
                    writer.WriteLine(csv);
                }
            }
        }
    }

    public bool Load(string _directory, string _path)
    {
        StreamReader reader = new StreamReader(_directory + _path);

        int counter = 0;
        string line = "";

        while ((line = reader.ReadLine()) != null)
        {
            if (line.Contains(m_commentString))
            {
                continue;
            }

            string[] fields = line.Split(SplitChar);
            m_data.Add(new List<string>());

            foreach (var field in fields)
            {
                if (field.Contains(m_commentString) || field == "")
                {
                    continue;
                }
                m_data[counter].Add(field);
            }
            counter++;
        }
        reader.Close();
        return true;
    }

    string GetString(int _row, int _col)
    {
        return m_data[_row][_col];
    }

    int GetInt(int _row, int _col)
    {
        string _data = GetString(_row, _col);
        return int.Parse(_data);
    }

    float GetFloat(int _row, int _col)
    {
        string _data = GetString(_row, _col);
        return float.Parse(_data);
    }

    bool GetBool(int _row, int _col)
    {
        string _data = GetString(_row, _col);
        return bool.Parse(_data);
    }

    double GetDouble(int _row, int _col)
    {
        string _data = GetString(_row, _col);
        return double.Parse(_data);
    }

}