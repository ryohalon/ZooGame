using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimalIDSetter : MonoBehaviour
{
    public GameObject animalList;
    public int ID;

    public GameObject BuyWindowPriceText;
    public GameObject BuyWindowYesButton;

    void Awake()
    {

    }

    public void SetID()
    {
        var buyWindowPrice = BuyWindowPriceText.GetComponent<PriceChanger>();
        var buyWindowYesButton = BuyWindowYesButton.GetComponent<AnimalBuyer>();
        buyWindowPrice.ID = ID;
        buyWindowYesButton.ID = ID;

        buyWindowPrice.UpdatePriceText();
    }
}