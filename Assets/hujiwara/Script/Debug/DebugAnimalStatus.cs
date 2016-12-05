using UnityEngine;
using System.Collections;

public class DebugAnimalStatus : MonoBehaviour
{
    public int ID { get; set; }

    public string Name { get; set; }

    public int purchasePrice { get; set; }

    public bool isPurchase { get; set; }

    public DebugAnimalStatus() { }

    public DebugAnimalStatus(
        int ID, string Name, int purchasePrice,
        bool isPurchase)
    {
        this.ID = ID;
        this.Name = Name;
        this.purchasePrice = purchasePrice;
        this.isPurchase = isPurchase;
    }
}