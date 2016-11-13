﻿using UnityEngine;
using System.Collections;

public class FoodIDSetter : MonoBehaviour
{
    public GameObject foodList;
    public int ID;

    public GameObject BuyWindowPriceText;
    public GameObject BuyWidnowYesButton;

    public void SetID()
    {
        var buyWinowPrice = BuyWindowPriceText.GetComponent<FoodPriceChanger>();
        var buyWindowYesButton = BuyWidnowYesButton.GetComponent<FoodBuyer>();
        buyWinowPrice.ID = ID;
        buyWindowYesButton.ID = ID;

        buyWinowPrice.UpdatePriceText();
    }
}
