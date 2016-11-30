using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodTotalPriceChanger : MonoBehaviour
{
    public GameObject foodList;
    FoodList food;

    public GameObject foodIDSetter;
    FoodIDSetter setter;

    public GameObject purchaseCountChanger;
    PurchaseCountChanger countChanger;

    int ID;

    int totalPrice;

    void Start()
    {
        food = new FoodList();
        food = foodList.GetComponent<FoodList>();

        setter = new FoodIDSetter();
        setter = foodIDSetter.GetComponent<FoodIDSetter>();

        countChanger = new PurchaseCountChanger();
        countChanger = purchaseCountChanger.GetComponent<PurchaseCountChanger>();

        ID = 0;

        totalPrice = 0;

        TextUpdater();
    }

    public void TextUpdater()
    {
        ID = setter.GetID();

        int price = food.foodList[ID].purchasePrice;
        int count = countChanger.GetCounter();

        var total = gameObject.GetComponent<Text>();
        total.text = Multiplication(price, count).ToString();
    }

    int Multiplication(int _price, int _possessionCount)
    {
        int _total = _price * _possessionCount;
        return _total;
    }
}