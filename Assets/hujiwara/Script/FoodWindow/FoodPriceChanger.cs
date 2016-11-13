using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodPriceChanger : MonoBehaviour
{
    public GameObject foodList;

    public int ID;

    private Text price;

    private DebugFoodList food;

    void Start()
    {
        food = foodList.GetComponent<DebugFoodList>();
        price = gameObject.GetComponent<Text>();

        UpdatePriceText();
    }

    public void UpdatePriceText()
    {
        if(food.foodList[ID].status_.grade == 0)
        {
            price.text = "100";
        }
        else if(food.foodList[ID].status_.grade == 1)
        {
            price.text = "200";
        }
        else if(food.foodList[ID].status_.grade == 2)
        {
            price.text = "300";
        }
    }
}
