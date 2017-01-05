using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject foodShelf = null;

    [SerializeField]
    GameObject UpperTwine = null;

    [SerializeField]
    GameObject foodShelfLabel = null;

    [SerializeField]
    GameObject foodBuyWindow = null;

    //購入画面 ご飯名
    [SerializeField]
    GameObject foodNameText = null;
    
    //購入画面 愛情度上昇値
    [SerializeField]
    GameObject loveDegreeUpValueText = null;
    
    //購入画面 満腹度上昇値
    [SerializeField]
    GameObject satietyLevelUpValueText = null;
    
    //購入画面 ご飯値段
    [SerializeField]
    GameObject foodPriceText = null;
    
    //購入画面 個数
    [SerializeField]
    GameObject foodNumberText = null;
    
    //購入画面 合計金額
    [SerializeField]
    GameObject totalPriceText = null;

    //購入画面 ご飯イメージ
    [SerializeField]
    GameObject foodImage = null;

    //購入画面 所持金不足テキスト
    [SerializeField]
    GameObject handMoneyMissingTextBoard = null;

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
    // ご飯個数選択用
    int foodNumber;
    // 合計金額
    int totalPrice;
    // 仮所持金(Debug)
    float handMoney;

    // 所持金不足テキストを表示する時間
    float time;
    // 所持金不足テキストが表示されたか
    bool isShowText;
    
    int ID = 0;
    // ご飯イメージ用
    Image img;

    void Awake()
    {
        foodStatus = gameObject.GetComponent<FoodStatus>();
        img = foodImage.GetComponent<Image>();

        handMoney = 0;
        time = 2;
        isShowText = false;
        
        FoodNumberReset();
        foodNumberText.GetComponent<Text>().text = foodNumber.ToString();
    }

    void Update()
    {
        if(isShowText)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                isShowText = false;
                handMoneyMissingTextBoard.SetActive(false);
                time = 2;
            }
        }
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
            foodStatus.foodList[_ID].purchasePrice.ToString() + "z";
    }

    void FoodNumberReset()
    {
        foodNumber = 1;
        foodNumberText.GetComponent<Text>().text = foodNumber.ToString();
    }

    void TotalTextUpdater()
    {
        totalPrice = foodStatus.foodList[ID].purchasePrice * foodNumber;
        totalPriceText.GetComponent<Text>().text = totalPrice.ToString() + "z";
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

    public void PushNoButton()
    {
        foodBuyWindow.SetActive(false);

        UpperTwine.SetActive(true);
        foodShelfLabel.SetActive(true);
        foodShelf.SetActive(true);
    }

    public void PushYesButton()
    {
        if(IsInPossessionMoney())
        {
            foodStatus.foodList[ID].possessionNumber += foodNumber;
            foodStatus.Save();
        }
        else
        {
            handMoneyMissingTextBoard.SetActive(true);
            isShowText = true;
        }
        
    }

    // 所持金内か
    bool IsInPossessionMoney()
    {
        if(handMoney >= totalPrice)
        {
            return true;
        }
        return false;
    }
}