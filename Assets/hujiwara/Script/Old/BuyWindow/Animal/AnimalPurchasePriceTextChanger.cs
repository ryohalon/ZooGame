using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimalPurchasePriceTextChanger : MonoBehaviour
{
    public GameObject animalIDSetter;
    AnimalIDSetter setter = null;

    public GameObject debugAnimalList;
    DebugAnimalList animalList = null;

    int ID;

    void Start()
    {
        setter = new AnimalIDSetter();
        setter = animalIDSetter.GetComponent<AnimalIDSetter>();

        animalList = new DebugAnimalList();
        animalList = debugAnimalList.GetComponent<DebugAnimalList>();

        ID = 0;

        TextUpdater();
    }

    public void TextUpdater()
    {
        ID = setter.GetID();

        var animalPurchasePrice = gameObject.GetComponent<Text>();
        animalPurchasePrice.text = animalList.debugAnimalList[ID].purchasePrice.ToString();
    }
}