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

        ID = setter.GetID();

        TextUpdater();
    }

    public void TextUpdater()
    {
        ID = setter.GetID();

        int price = food.foodList[ID].purchasePrice;
        int count = countChanger.GetCounter();

        totalPrice = Multiplication(price, count);

        var total = gameObject.GetComponent<Text>();
        total.text = totalPrice.ToString();
    }

    int Multiplication(int _price, int _count)
    {
        int _total = _price * _count;
        return _total;
    }

    public int GetTotalPrice()
    {
        return totalPrice;
    }


}