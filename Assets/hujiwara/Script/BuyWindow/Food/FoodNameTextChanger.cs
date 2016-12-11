using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodNameTextChanger : MonoBehaviour
{
    public GameObject foodList;
    FoodList food = null;

    public GameObject foodIDSetter;
    FoodIDSetter setter = null;

    int ID;

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

        var Name = gameObject.GetComponent<Text>();
        Name.text = food.foodList[ID].Name.ToString();
    }
}