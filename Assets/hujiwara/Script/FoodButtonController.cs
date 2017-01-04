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
    GameObject foodNumberText = null;

    [SerializeField]
    GameObject totalPriceText = null;

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

    int foodNumber;

    int ID = 0;

    Image img;

    void Awake()
    {
        foodStatus = gameObject.GetComponent<FoodStatus>();
        img = foodImage.GetComponent<Image>();
        
        FoodNumberReset();
        foodNumberText.GetComponent<Text>().text = foodNumber.ToString();
    }

    public void PushMeet1()
    {
        ID = foodStatus.foodList[0].ID;

        SetInformation(ID);
        img.material.mainTexture = meet1;

        FoodNumberReset();
        TotalTextUpdater();
    }

    public void PushMeet2()
    {
        ID = foodStatus.foodList[1].ID;

        SetInformation(ID);
        img.material.mainTexture = meet2;

        FoodNumberReset();
        TotalTextUpdater();
    }

    public void PushMeet3()
    {
        ID = foodStatus.foodList[2].ID;

        SetInformation(ID);
        img.material.mainTexture = meet3;

        FoodNumberReset();
        TotalTextUpdater();
    }

    public void PushVegetable1()
    {
        ID = foodStatus.foodList[3].ID;

        SetInformation(ID);
        img.material.mainTexture = vegetable1;

        FoodNumberReset();
        TotalTextUpdater();
    }

    public void PushVegetable2()
    {
        ID = foodStatus.foodList[4].ID;

        SetInformation(ID);
        img.material.mainTexture = vegetable2;

        FoodNumberReset();
        TotalTextUpdater();
    }

    public void PushVegetable3()
    {
        ID = foodStatus.foodList[5].ID;

        SetInformation(ID);
        img.material.mainTexture = vegetable3;

        FoodNumberReset();
        TotalTextUpdater();
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

    void FoodNumberReset()
    {
        foodNumber = 1;
        foodNumberText.GetComponent<Text>().text = foodNumber.ToString();
    }

    void TotalTextUpdater()
    {
        int totalPrice = foodStatus.foodList[ID].purchasePrice * foodNumber;
        totalPriceText.GetComponent<Text>().text = totalPrice.ToString();
    }

    public void PushPlusOne()
    {
        if(!isUpperRimit())
        {
            foodNumber += 1;
        }

        foodNumberText.GetComponent<Text>().text = foodNumber.ToString();
        TotalTextUpdater();
    }

    public void PushPlusTen()
    {
        if (isPlusTen())
        {
            foodNumber = 99;
        }
        else
        {
            if (!isUpperRimit())
            {
                foodNumber += 10;
            }
        }

        foodNumberText.GetComponent<Text>().text = foodNumber.ToString();
        TotalTextUpdater();
    }

    public void PushMinusOne()
    {
        if(!isBottomLimit())
        {
            foodNumber -= 1;
        }

        foodNumberText.GetComponent<Text>().text = foodNumber.ToString();
        TotalTextUpdater();
    }

    public void PushMinusTen()
    {
        if(isMinusTen())
        {
            foodNumber = 1;
        }
        else
        {
            if(!isBottomLimit())
            {
                foodNumber -= 10;
            }
        }

        foodNumberText.GetComponent<Text>().text = foodNumber.ToString();
        TotalTextUpdater();
    }

    bool isUpperRimit()
    {
        if(foodNumber >= 99)
        {
            foodNumber = 99;
            return true;
        }
        return false;
    }

    bool isPlusTen()
    {
        if(!isUpperRimit() &&
            (foodNumber >= 90 &&
            foodNumber <= 99))
        {
            foodNumber += 10;
            return true;
        }

        return false;
    }

    bool isBottomLimit()
    {
        if(foodNumber <= 1)
        {
            foodNumber = 1;
            return true;
        }
        return false;
    }

    bool isMinusTen()
    {
        if(!isUpperRimit() &&
            (foodNumber >= 1 &&
            foodNumber <= 10))
        {
            foodNumber -= 10;
            return true;
        }

        return false;
    }

    public void PushFoodYesButton()
    {
        foodStatus.foodList[ID].possessionNumber += 1;
        Debug.Log("ID= " + ID + ", " + foodStatus.foodList[ID].possessionNumber);
        foodStatus.Save();
    }
}