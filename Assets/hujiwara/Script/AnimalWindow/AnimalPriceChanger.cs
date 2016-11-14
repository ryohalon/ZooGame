using UnityEngine;
using UnityEngine.UI;

public class AnimalPriceChanger : MonoBehaviour
{
    public GameObject animalList;

    public int ID = 0;

    public int price;
    private Text priceText;

    private DebugShopAnimalList animal;

    void Start()
    {
       animal = animalList.GetComponent<DebugShopAnimalList>();
       priceText = gameObject.GetComponent<Text>();

       UpdatePriceText();
    }

    public void UpdatePriceText()
    {
        if (animal.animalList[ID].status.Rarity == 0)
        {
            price = animal.animalList[ID].status.PurchasePrice;
            priceText.text = price.ToString();
        }
        else if (animal.animalList[ID].status.Rarity == 1)
        {
            price = animal.animalList[ID].status.PurchasePrice;
            priceText.text = price.ToString();
        }
        else if (animal.animalList[ID].status.Rarity == 2)
        {
            price = animal.animalList[ID].status.PurchasePrice;
            priceText.text = price.ToString();
        }
        else if (animal.animalList[ID].status.Rarity == 3)
        {
            price = animal.animalList[ID].status.PurchasePrice;
            priceText.text = price.ToString();
        }
        else if (animal.animalList[ID].status.Rarity == 4)
        {
            price = animal.animalList[ID].status.PurchasePrice;
            priceText.text = price.ToString();
        }
    }
}
