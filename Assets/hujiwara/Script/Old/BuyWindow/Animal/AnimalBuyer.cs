using UnityEngine;
using System.Collections;

public class AnimalBuyer : MonoBehaviour
{
    public GameObject debugAnimalList;
    DebugAnimalList animalList = null;

    public GameObject animalIDSetter;
    AnimalIDSetter setter = null;

    public GameObject handMoneyText;
    HandMoneyChanger handMoneyChanger = null;

    public GameObject missingImage;
    ImageFadeouter fadeOuter = new ImageFadeouter();
    

    int ID;

    string directory;
    string path;

    void Start()
    {
        animalList = new DebugAnimalList();
        animalList = debugAnimalList.GetComponent<DebugAnimalList>();

        setter = new AnimalIDSetter();
        setter = animalIDSetter.GetComponent<AnimalIDSetter>();

        handMoneyChanger = new HandMoneyChanger();
        handMoneyChanger = handMoneyText.GetComponent<HandMoneyChanger>();

        fadeOuter = missingImage.GetComponent<ImageFadeouter>();

        ID = 0;
    }

    public void Sell()
    {
        ID = setter.GetID();
        
        if(handMoneyChanger.isAnimalPriceInHandMoney())
        {
            animalList.debugAnimalList[ID].isPurchase = true;
            Debug.Log("ID=[" + ID + "]" + animalList.debugAnimalList[ID].isPurchase);
        }
        else
        {
            fadeOuter.Fadeout();
        }

        handMoneyChanger.BuyAnimal();
        handMoneyChanger.TextUpdater();
    }
}