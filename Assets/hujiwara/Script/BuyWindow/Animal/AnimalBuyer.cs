using UnityEngine;
using System.Collections;

public class AnimalBuyer : MonoBehaviour
{
    public GameObject animalList;
    public int ID;

    private DebugShopAnimalList animal;

    void Awake()
    {
        animal = animalList.GetComponent<DebugShopAnimalList>();
    }

    public void Sell()
    {
        if(animal.animalList[ID].status.IsPurchase == false)
        {
            animal.animalList[ID].status.IsPurchase = true;
        }

        Debug.Log(animal.animalList[ID].status.IsPurchase);
    }
}
