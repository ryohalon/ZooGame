using UnityEngine;
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

    public GameObject animalNameTextChanger;
    AnimalNameChanger nameTextChanger = null;

    public GameObject animalImage;
    AnimalImageSetter imageSetter;

    void Start()
    {
        nameChanger = new AnimalNameChanger();
        nameChanger = animalNameChanger.GetComponent<AnimalNameChanger>();
        
        purchasePriceChanger = new AnimalPurchasePriceTextChanger();
        purchasePriceChanger = animalPurchasePriceText.GetComponent<AnimalPurchasePriceTextChanger>();

        handMoneyChanger = new HandMoneyChanger();
        handMoneyChanger = handMoneyText.GetComponent<HandMoneyChanger>();

        nameTextChanger = new AnimalNameChanger();
        nameTextChanger = animalNameTextChanger.GetComponent<AnimalNameChanger>();

        imageSetter = new AnimalImageSetter();
        imageSetter = animalImage.GetComponent<AnimalImageSetter>();
    }

    public void SetID(int readID)
    {
        ID = readID;
        nameChanger.TextUpdater();
        purchasePriceChanger.TextUpdater();
        handMoneyChanger.TextUpdater();
        nameTextChanger.TextUpdater();
        imageSetter.ImageUpdater();
    }

    public int GetID()
    {
        return ID;
    }
}