using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TotalMoney : MonoBehaviour
{
    public GameObject foodList;
    private DebugFoodList food;

    public int price;

    public int number;
    public int ID;

    private int totalMoney;

    void Start()
    {
        food = foodList.GetComponent<DebugFoodList>();

        UpdateTotalMoneyText();
    }

    public void UpdateTotalMoneyText()
    {
        if (food.foodList[ID].status_.grade == 0)
        {
            price = 100;
        }
        else if (food.foodList[ID].status_.grade == 1)
        {
            price = 200;
        }
        else if (food.foodList[ID].status_.grade == 2)
        {
            price = 300;
        }

        totalMoney = price * number;

        gameObject.GetComponent<Text>().text = totalMoney.ToString();
    }
}