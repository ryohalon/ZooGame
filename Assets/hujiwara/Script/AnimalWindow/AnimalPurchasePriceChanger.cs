using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimalPurchasePriceChanger : MonoBehaviour
{
    public GameObject debugAnimalList;
    DebugAnimalList animalList;

    public int ID;

    void Awake()
    {
        animalList = new DebugAnimalList();
        animalList = debugAnimalList.GetComponent<DebugAnimalList>();

        Debug.Log("OK!");
    }

    void Start()
    {
        var price = gameObject.GetComponent<Text>();
        price.text = animalList.debugAnimalList[ID].purchasePrice.ToString();
    }
}