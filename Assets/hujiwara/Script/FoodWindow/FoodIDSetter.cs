using UnityEngine;
using UnityEngine.UI;

public class FoodIDSetter : MonoBehaviour
{
    int ID;

    public GameObject foodPriceChanger;
    FoodPriceChanger priceChanger;

    public GameObject foodNameTextChanger;
    FoodNameTextChanger nameChanger;

    public GameObject foodLoveDegreeChanger;
    FoodLoveDegreeChanger loveDegreeChanger;

    public GameObject foodSatietyLevelChanger;
    FoodSatietyLevelChanger satietyLevelChanger;

    public GameObject foodTotalPriceChanger;
    FoodTotalPriceChanger totalPriceChanger;

    public GameObject handMoneyChanger;
    HandMoneyChanger moneyChanger;

    void Start()
    {
        priceChanger = new FoodPriceChanger();
        priceChanger = foodPriceChanger.GetComponent<FoodPriceChanger>();

        nameChanger = new FoodNameTextChanger();
        nameChanger = foodNameTextChanger.GetComponent<FoodNameTextChanger>();

        loveDegreeChanger = new FoodLoveDegreeChanger();
        loveDegreeChanger = foodLoveDegreeChanger.GetComponent<FoodLoveDegreeChanger>();

        satietyLevelChanger = new FoodSatietyLevelChanger();
        satietyLevelChanger = foodSatietyLevelChanger.GetComponent<FoodSatietyLevelChanger>();

        totalPriceChanger = new FoodTotalPriceChanger();
        totalPriceChanger = foodTotalPriceChanger.GetComponent<FoodTotalPriceChanger>();

        moneyChanger = new HandMoneyChanger();
        moneyChanger = handMoneyChanger.GetComponent<HandMoneyChanger>();
    }

    public void SetID(int readID)
    {
        ID = readID;
        priceChanger.TextUpdater();
        nameChanger.TextUpdater();
        loveDegreeChanger.TextUpdater();
        satietyLevelChanger.TextUpdater();
        totalPriceChanger.TextUpdater();
    }

    public int GetID()
    {
        return ID;
    }
}