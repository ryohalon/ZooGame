using UnityEngine;
using UnityEngine.UI;

public class FoodIDSetter : MonoBehaviour
{
    int ID;

    public GameObject foodPriceChanger;
    FoodPriceChanger priceChanger;

    void Start()
    {
        priceChanger = new FoodPriceChanger();
        priceChanger = foodPriceChanger.GetComponent<FoodPriceChanger>();
    }

    public void SetID(int readID)
    {
        ID = readID;
        priceChanger.TextUpdater();
    }

    public int GetID()
    {
        return ID;
    }
}