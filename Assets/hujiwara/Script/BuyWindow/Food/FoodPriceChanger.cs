using UnityEngine;
using UnityEngine.UI;

public class FoodPriceChanger : MonoBehaviour
{
    public GameObject foodList;
    FoodList food = null;

    public GameObject foodIDSetter;
    FoodIDSetter setter = null;

    int ID;

    int price;

    void Start()
    {
        food = foodList.GetComponent<FoodList>();

        setter = new FoodIDSetter();
        setter = foodIDSetter.GetComponent<FoodIDSetter>();

        ID = 0;

        TextUpdater();
    }

    public void TextUpdater()
    {
        ID = setter.GetID();

        var price = gameObject.GetComponent<Text>();
        price.text = food.foodList[ID].purchasePrice.ToString();
    }
}