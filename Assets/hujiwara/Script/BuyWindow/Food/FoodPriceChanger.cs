using UnityEngine;
using UnityEngine.UI;

public class FoodPriceChanger : MonoBehaviour
{
    public GameObject foodList;
    FoodList food;

    public GameObject foodIDSetter;
    FoodIDSetter setter;

    int ID;

    void Start()
    {
        food = new FoodList();
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