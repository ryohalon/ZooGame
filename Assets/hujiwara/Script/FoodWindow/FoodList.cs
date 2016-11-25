using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FoodList : MonoBehaviour
{
    public List<FoodStatusManager2> foodList;
    // 読み込むファイル名(csv専用です。)
    string path = "FoodStatus.csv";

    bool isCreate;

    // CSVReaderを参照してください。
    CSVReader reader;

    CSVReader saveDataReader;

    void Awake()
    {
        foodList = new List<FoodStatusManager2>();

        reader = new CSVReader();
        saveDataReader = new CSVReader();
        // 読み込み
        reader.Load(Application.dataPath + "/" + path);
        saveDataReader.Load(Application.persistentDataPath + "/" + "sample.csv");
        isCreate = false;
    }

    void Start()
    {
        // テストしてないけどシーン移行時消されないようにしてます多分
        if (!isCreate)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < 6; ++i)
        {
            foodList.Add(new FoodStatusManager2());
        }

        // csvデータから読み込んでデータを入れてます。
        // 使うときは foodList[0].Name のように使ってください。
        for (int i = 0; i < 6; ++i)
        {
            foodList[i].ID = reader.GetInt(i, 0);
            foodList[i].Name = reader.GetString(i, 1);
            foodList[i].purchasePrice = reader.GetInt(i, 2);
            foodList[i].loveDegreeUpValue = reader.GetFloat(i, 3);
            foodList[i].satietyLevelUpValue = reader.GetFloat(i, 4);
            foodList[i].foodType = reader.GetInt(i, 5);

            if(File.Exists(Application.persistentDataPath + "/" + "sample.csv"))
            {
                foodList[i].possessionNumber = saveDataReader.GetInt(i, 1);
                Debug.Log(foodList[i].possessionNumber);
            }
            else
            {
                foodList[i].possessionNumber = reader.GetInt(i, 6);
            }
            
        }
    }
}