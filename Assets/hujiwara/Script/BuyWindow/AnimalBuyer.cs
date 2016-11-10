using UnityEngine;
using System.Collections;

public class AnimalBuyer : MonoBehaviour
{
    AnimalStatusManager animalStatus;

    public void Sell()
    {
        if(!animalStatus.IsPurchase)
        {
            animalStatus.IsPurchase = true;
        }
    }
}
