using UnityEngine;
using System.Collections;

public class AnimalBuyer : MonoBehaviour
{
    public GameObject animalStatusManager;

    void Start()
    {
        Debug.Log(animalStatusManager.GetComponent<AnimalStatusManager>().status.IsPurchase);
    }

    public void Sell()
    {
        var animal = animalStatusManager.GetComponent<AnimalStatusManager>();

        if(!animal.status.IsPurchase)
        {
            animal.status.IsPurchase = true;
            Debug.Log("購入しました");
            Debug.Log(animal.status.IsPurchase);
        }
    }
}
