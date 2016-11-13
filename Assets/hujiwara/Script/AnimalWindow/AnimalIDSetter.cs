using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimalIDSetter : MonoBehaviour
{
    public GameObject animalList;
    public int ID;

    public GameObject BuyWindowPriceText;

    void Awake()
    {

    }

    public void SetID()
    {
        var buyWindowPrice = BuyWindowPriceText.GetComponent<PriceChanger>();
        buyWindowPrice.ID = ID;

        buyWindowPrice.UpdatePriceText();
    }
}