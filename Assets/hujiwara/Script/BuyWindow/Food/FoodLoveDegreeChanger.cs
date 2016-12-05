using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodLoveDegreeChanger : MonoBehaviour
{
    public GameObject foodList;
    FoodList food = null;

    public GameObject foodIDSetter;
    FoodIDSetter setter = null;

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

        var loveDegreeText = gameObject.GetComponent<Text>();
        loveDegreeText.text = "+" + food.foodList[ID].loveDegreeUpValue.ToString();
    }
}