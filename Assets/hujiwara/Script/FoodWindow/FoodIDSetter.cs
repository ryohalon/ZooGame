using UnityEngine;
using UnityEngine.UI;

public class FoodIDSetter : MonoBehaviour
{
    int ID;

    public GameObject foodPriceChanger;
    FoodPriceChanger priceChanger = null;

    public GameObject foodNameTextChanger;
    FoodNameTextChanger nameChanger = null;

    public GameObject foodLoveDegreeChanger;
    FoodLoveDegreeChanger loveDegreeChanger = null;

    public GameObject foodSatietyLevelChanger;
    FoodSatietyLevelChanger satietyLevelChanger = null;

    public GameObject foodTotalPriceChanger;
    FoodTotalPriceChanger totalPriceChanger = null;

    public GameObject handMoneyChanger;
    HandMoneyChanger moneyChanger = null;

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