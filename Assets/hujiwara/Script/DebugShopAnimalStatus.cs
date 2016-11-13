using UnityEngine;
using System.Collections;

public class DebugShopAnimalStatus : MonoBehaviour
{
    public struct AnimalStatus_
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rarerity { get; set; }
        public int PurchasePrice { get; set; }
        public bool IsPurchase { get; set; }
    }
    public AnimalStatus_ status;
}
