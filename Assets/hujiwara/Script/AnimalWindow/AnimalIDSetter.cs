﻿using UnityEngine;
using System.Collections;

public class AnimalIDSetter : MonoBehaviour
{
    int ID;

    public GameObject animalNameChanger;
    AnimalNameChanger nameChanger = null;

    public GameObject animalPurchasePriceText;
    AnimalPurchasePriceTextChanger purchasePriceChanger = null;

    public GameObject handMoneyText;
    HandMoneyChanger handMoneyChanger = null;

    void Start()
    {
        nameChanger = new AnimalNameChanger();
        nameChanger = animalNameChanger.GetComponent<AnimalNameChanger>();
        
        purchasePriceChanger = new AnimalPurchasePriceTextChanger();
        purchasePriceChanger = animalPurchasePriceText.GetComponent<AnimalPurchasePriceTextChanger>();

        handMoneyChanger = new HandMoneyChanger();
        handMoneyChanger = handMoneyText.GetComponent<HandMoneyChanger>();
    }

    public void SetID(int readID)
    {
        ID = readID;
        nameChanger.TextUpdater();
        purchasePriceChanger.TextUpdater();
        handMoneyChanger.TextUpdater();
    }

    public int GetID()
    {
        return ID;
    }
}