using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class HandMoneyChanger : MonoBehaviour
{
    public GameObject PlayerStatus;
    DebugPlayerStatus status;

    public GameObject foodList;
    FoodList food;

    public GameObject foodIDSetter;
    FoodIDSetter foodSetter;

    public GameObject foodTotalText;
    FoodTotalPriceChanger foodTotalChanger;

    public GameObject debugAnimalList;
    DebugAnimalList animalList;

    public GameObject animalIDSetter;
    AnimalIDSetter animalSetter;

    int handMoney;

    int animalID;

    void Awake()
    {
        status = new DebugPlayerStatus();
        status = PlayerStatus.GetComponent<DebugPlayerStatus>();

        food = new FoodList();
        food = foodList.GetComponent<FoodList>();

        foodSetter = new FoodIDSetter();
        foodSetter = foodIDSetter.GetComponent<FoodIDSetter>();

        foodTotalChanger = new FoodTotalPriceChanger();
        foodTotalChanger = foodTotalText.GetComponent<FoodTotalPriceChanger>();

        animalList = new DebugAnimalList();
        animalList = debugAnimalList.GetComponent<DebugAnimalList>();

        animalSetter = new AnimalIDSetter();
        animalSetter = animalIDSetter.GetComponent<AnimalIDSetter>();

        Save();
    }

    void Start()
    {
        handMoney = status.GetHandMoney();

        animalID = 0;

        var money = gameObject.GetComponent<Text>();
        money.text = handMoney.ToString();
    }

    public void TextUpdater()
    {
        var money = gameObject.GetComponent<Text>();
        money.text = handMoney.ToString();
    }

    public void BuyFood()
    {
        if (isFoodPriceInHandMoney())
        {
            handMoney = handMoney - foodTotalChanger.GetTotalPrice();
            Save();
        }
        else
        {
            Debug.Log("お金がたりません");
        }
    }

    public void BuyAnimal()
    {
        if(isAnimalPriceInHandMoney())
        {
            handMoney = handMoney - animalList.debugAnimalList[animalID].purchasePrice;
            Save();
        }
        else
        {
            Debug.Log("お金が足りません");
        }
    }

    public bool isFoodPriceInHandMoney()
    {
        if(handMoney >= foodTotalChanger.GetTotalPrice())
        {
            return true;
        }

        return false;
    }

    public bool isAnimalPriceInHandMoney()
    {
        animalID = animalSetter.GetID();

        if(handMoney >= animalList.debugAnimalList[animalID].purchasePrice)
        {
            return true;
        }

        return false;
    }

    void Save()
    {
        string directory = Application.persistentDataPath + "/";
        string path = "HandMoneySave.txt";

        if(File.Exists(directory+path))
        {
            using (var stream = new FileStream(directory + path, FileMode.Open))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(handMoney);
                }
            }
        }
        else
        {
            using (var stream = new FileStream(directory + path, FileMode.Create))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(handMoney);
                }
            }
        }
    }
}