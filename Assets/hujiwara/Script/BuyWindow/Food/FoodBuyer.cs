using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;

public class FoodBuyer : MonoBehaviour
{
    public GameObject foodList;
    FoodList food = null;

    public GameObject foodIDSetter;
    FoodIDSetter setter = new FoodIDSetter();

    public GameObject purchaseCountChanger;
    PurchaseCountChanger countChanger = new PurchaseCountChanger();

    public GameObject handMoneyText;
    HandMoneyChanger handMoneyChanger = new HandMoneyChanger();

    public GameObject missingImage;
    ImageFadeouter fadeouter = new ImageFadeouter();
    
    int ID;

    string directory;
    string path;
    
    void Start()
    {
        food = foodList.GetComponent<FoodList>();

        setter = new FoodIDSetter();
        setter = foodIDSetter.GetComponent<FoodIDSetter>();

        countChanger = new PurchaseCountChanger();
        countChanger = purchaseCountChanger.GetComponent<PurchaseCountChanger>();

        handMoneyChanger = new HandMoneyChanger();
        handMoneyChanger = handMoneyText.GetComponent<HandMoneyChanger>();

        fadeouter = new ImageFadeouter();
        fadeouter = missingImage.GetComponent<ImageFadeouter>();

        ID = 0;

        directory = Application.dataPath + "/" + "hujiwara" + "/";
        path = "FoodStatus.csv";
    }

    public void Sell()
    {
        ID = setter.GetID();

        if(handMoneyChanger.isFoodPriceInHandMoney())
        {
            food.foodList[ID].possessionNumber += countChanger.GetCounter();
        }
        else
        {
            fadeouter.Fadeout();
        }

        if(File.Exists(directory+path))
        {
            using (var stream = new FileStream(directory + path, FileMode.Open))
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    string csv = string.Empty;
                    csv += "//ID" + "," + "//名前" + "," + "//値段" + "," + "//愛情度上昇値" + "," + "//満腹度上昇値" + "," + "//種類" + "," + "//初期所持数";
                    csv += "\n";
                    for(int i = 0; i < 6; ++i)
                    {
                        csv += food.foodList[i].ID;
                        csv += ",";
                        csv += food.foodList[i].Name;
                        csv += ",";
                        csv += food.foodList[i].purchasePrice;
                        csv += ",";
                        csv += food.foodList[i].loveDegreeUpValue;
                        csv += ",";
                        csv += food.foodList[i].satietyLevelUpValue;
                        csv += ",";
                        csv += food.foodList[i].foodType;
                        csv += ",";
                        csv += food.foodList[i].possessionNumber;
                        csv += "\n";
                    }
                    writer.WriteLine(csv);
                }
            }
        }
        else
        {
            using (var stream = new FileStream(directory + path, FileMode.Create))
            {
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    string csv = string.Empty;
                    csv += "//ID" + "," + "//名前" + "," + "//値段" + "," + "//愛情度上昇値" + "," + "//満腹度上昇値" + "," + "//種類" + "," + "//初期所持数";
                    csv += "\n";
                    for (int i = 0; i < 6; ++i)
                    {
                        csv += food.foodList[i].ID;
                        csv += ",";
                        csv += food.foodList[i].Name;
                        csv += ",";
                        csv += food.foodList[i].purchasePrice;
                        csv += ",";
                        csv += food.foodList[i].loveDegreeUpValue;
                        csv += ",";
                        csv += food.foodList[i].satietyLevelUpValue;
                        csv += ",";
                        csv += food.foodList[i].foodType;
                        csv += ",";
                        csv += food.foodList[i].possessionNumber;
                        csv += "\n";
                    }
                    writer.WriteLine(csv);
                }
            }
        }



        handMoneyChanger.BuyFood();
        handMoneyChanger.TextUpdater();

        for(int i = 0; i < 6; ++i)
        {
            Debug.Log("foodID[" + i + "]=" + food.foodList[i].possessionNumber);
        }
    }

    // 以下セーブ関係
    void Saver()
    {
        List<List<int>> data = new List<List<int>>();
        for(int i = 0; i < 6; ++i)
        {
            List<int> line = new List<int>();
            line.Add(food.foodList[i].ID);
            line.Add(food.foodList[i].possessionNumber);
            data.Add(line);
        }
        MapCSVSaver(data, directory, path);
    }

    void MapCSVSaver(List<List<int>> data, string _directory, string _path)
    {
        string save = string.Empty;
        for(int i = 0; i < data.Count-1; ++i)
        {
            save += LineCSVMaker(data[i]);
            save += "\n";
        }
        save += LineCSVMaker(data[data.Count - 1]);

        Writer(save, _directory, _path);
    }

    string LineCSVMaker(List<int> data)
    {
        string csv = string.Empty;

        for(int i = 0; i < data.Count-1; ++i)
        {
            csv += data[i].ToString();
            csv += ",";
        }
        csv += data[data.Count - 1].ToString();

        return csv;
    }

    void Writer(string data, string _directory, string _path)
    {
        using (var stream = new FileStream(_directory + _path, FileMode.OpenOrCreate))
        {
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.WriteLine(data);
            }
        }
    }
}
