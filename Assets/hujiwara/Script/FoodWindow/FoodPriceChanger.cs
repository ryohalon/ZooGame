using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodPriceChanger : MonoBehaviour
{
    public GameObject foodList;

    public int ID;

    public int price;
    private Text priceText;

    private DebugFoodList food;

    void Start()
    {
        food = foodList.GetComponent<DebugFoodList>();
        priceText = gameObject.GetComponent<Text>();

        UpdatePriceText();
    }

    public void UpdatePriceText()
    {
        if(food.foodList[ID].status_.grade == 0)
        {
            price = 100;
            priceText.text = price.ToString();
        }
        else if(food.foodList[ID].status_.grade == 1)
        {
            price = 200;
            priceText.text = price.ToString();
        }
        else if(food.foodList[ID].status_.grade == 2)
        {
            price = 300;
            priceText.text = price.ToString();
        }
    }
}
