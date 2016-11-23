using UnityEngine;
using System.Collections;

public class FoodIDSetter : MonoBehaviour
{
    public GameObject foodList;
    public int ID;

    public GameObject BuyWindowPriceText;
    public GameObject BuyWidnowYesButton;
    public GameObject BuyWindowTotalText;

    public void SetID()
    {
        var buyWinowPrice = BuyWindowPriceText.GetComponent<FoodPriceChanger>();
        var buyWindowYesButtonBuyer = BuyWidnowYesButton.GetComponent<FoodBuyer>();
        var buyWindowTotalText = BuyWindowTotalText.GetComponent<TotalMoney>();
        buyWinowPrice.ID = ID;
        buyWindowYesButtonBuyer.ID = ID;
        buyWindowTotalText.ID = ID;

        buyWinowPrice.UpdatePriceText();
        buyWindowTotalText.UpdateTotalMoneyText();
    }
}
