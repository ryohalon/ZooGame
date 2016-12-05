using UnityEngine;
using UnityEngine.UI;

public class CountChanger : MonoBehaviour
{
    public GameObject countText;
    PurchaseCountChanger counterText = null;

    public GameObject totalText;
    FoodTotalPriceChanger totalChanger = null;

    void Start()
    {
        counterText = countText.GetComponent<PurchaseCountChanger>();

        totalChanger = new FoodTotalPriceChanger();
        totalChanger = totalText.GetComponent<FoodTotalPriceChanger>();
    }

    public void AddOne()
    {
        if(!UpperLimit())
        {
            counterText.counter += 1;
        }
        counterText.TextUpdater();
        totalChanger.TextUpdater();
    }

    public void AddTen()
    {
        if(isAddTen())
        {
            counterText.counter = 99;
        }
        else
        {
            if(!UpperLimit())
            {
                counterText.counter += 10;
            }
        }
        counterText.TextUpdater();
        totalChanger.TextUpdater();
    }

    bool isAddTen()
    {
        if(!UpperLimit() &&
            (counterText.counter >= 90 &&
            counterText.counter <= 99)
            )
        {
            counterText.counter += 10;
            return true;
        }

        return false;
    }

    public void MinusOne()
    {
        if(!BottomLimit())
        {
            counterText.counter -= 1;
        }
        counterText.TextUpdater();
        totalChanger.TextUpdater();
    }

    public void MinusTen()
    {
        if(isMinusTen())
        {
            counterText.counter = 1;
        }
        else
        {
            if(!BottomLimit())
            {
                counterText.counter -= 10;
            }
        }
        counterText.TextUpdater();
        totalChanger.TextUpdater();
    }

    bool isMinusTen()
    {
        if (!UpperLimit() &&
            (counterText.counter >= 1 &&
            counterText.counter <= 10)
            )
        {
            counterText.counter -= 10;
            return true;
        }

        return false;
    }

    bool UpperLimit()
    {
        if(counterText.counter >= 99)
        {
            counterText.counter = 99;
            return true;
        }

        return false;
    }

    bool BottomLimit()
    {
        if (counterText.counter <= 1)
        {
            counterText.counter = 1;
            return true;
        }

        return false;
    }
}