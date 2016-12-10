using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FoodList : MonoBehaviour
{
    public List<FoodStatusManager2> foodList = new List<FoodStatusManager2>();
    // 読み込むファイル名(csv専用です。)

    string directory;
    string path;

    // スクリプトCSVReaderを参照してください。
    CSVReader reader = new CSVReader();

    CSVReader saveDataReader = new CSVReader();

    public static bool init = false;
    public static FoodList _instance = new FoodList();

    void Awake()
    {
        if(!init)
        {
            init = true;
            DontDestroyOnLoad(this);
        }
        //if (_instance == null)
        //{
        //    _instance = this;
            
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

        reader = new CSVReader();

        directory = Application.dataPath + "/" + "hujiwara" + "/";
        path = "FoodStatus.csv";

        // 元になるご飯のデータを読み込んでいます。
        reader.Load(directory + path);
    }

    void Start()
    {
        reader.Load(directory + path);

        for (int i = 0; i < 6; ++i)
        {
            foodList.Add(new FoodStatusManager2());
        }

        // csvデータから読み込んでデータを入れてます。
        // 使うときは foodList[0].Name のように使ってください。
        for (int i = 0; i < 6; ++i)
        {
            if (File.Exists(directory + path))
            {
                foodList[i].ID = reader.GetInt(i, 0);
                foodList[i].Name = reader.GetString(i, 1);
                foodList[i].purchasePrice = reader.GetInt(i, 2);
                foodList[i].loveDegreeUpValue = reader.GetFloat(i, 3);
                foodList[i].satietyLevelUpValue = reader.GetFloat(i, 4);
                foodList[i].foodType = reader.GetInt(i, 5);
                foodList[i].possessionNumber = reader.GetInt(i, 6);
            }
        }
    }
}