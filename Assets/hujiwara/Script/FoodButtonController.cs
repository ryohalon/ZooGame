using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject foodNameText = null;

    [SerializeField]
    GameObject loveDegreeUpValueText = null;

    [SerializeField]
    GameObject satietyLevelUpValueText = null;

    [SerializeField]
    GameObject foodPriceText = null;

    [SerializeField]
    GameObject foodImage = null;

    [SerializeField]
    Texture meet1 = null;

    [SerializeField]
    Texture meet2 = null;

    [SerializeField]
    Texture meet3 = null;

    [SerializeField]
    Texture vegetable1 = null;

    [SerializeField]
    Texture vegetable2 = null;

    [SerializeField]
    Texture vegetable3 = null;

    FoodStatus foodStatus;

    int ID;

    Image img;

    void Awake()
    {
        foodStatus = gameObject.GetComponent<FoodStatus>();
        img = foodImage.GetComponent<Image>();
    }

    public void PushMeet1()
    {
        ID = foodStatus.foodList[0].ID;

        SetInformation(ID);
        img.material.mainTexture = meet1;
    }

    public void PushMeet2()
    {
        ID = foodStatus.foodList[1].ID;

        SetInformation(ID);
        img.material.mainTexture = meet2;
    }

    public void PushMeet3()
    {
        ID = foodStatus.foodList[2].ID;

        SetInformation(ID);
        img.material.mainTexture = meet3;
    }

    public void PushVegetable1()
    {
        ID = foodStatus.foodList[3].ID;

        SetInformation(ID);
        img.material.mainTexture = vegetable1;
    }

    public void PushVegetable2()
    {
        ID = foodStatus.foodList[4].ID;

        SetInformation(ID);
        img.material.mainTexture = vegetable2;
    }

    public void PushVegetable3()
    {
        ID = foodStatus.foodList[5].ID;

        SetInformation(ID);
        img.material.mainTexture = vegetable3;
    }

    void SetInformation(int _ID)
    {
        foodNameText.GetComponent<Text>().text =
            foodStatus.foodList[_ID].Name;
        loveDegreeUpValueText.GetComponent<Text>().text =
            foodStatus.foodList[_ID].loveDegreeUpValue.ToString();
        satietyLevelUpValueText.GetComponent<Text>().text =
            foodStatus.foodList[_ID].satietyLevelUpValue.ToString();
        foodPriceText.GetComponent<Text>().text =
            foodStatus.foodList[_ID].purchasePrice.ToString();
    }

    public void PushFoodYesButton()
    {
        foodStatus.Save();
    }
}