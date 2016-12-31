using UnityEngine;
using System.Collections;

public class SetActive : MonoBehaviour
{
    public GameObject foodComm;
    public GameObject animalComm;

    public GameObject handMoneyText;
    HandMoneyChanger handMoneyChanger = null;

    void Start()
    {
        handMoneyChanger = new HandMoneyChanger();
        handMoneyChanger = handMoneyText.GetComponent<HandMoneyChanger>();
    }

    public void SetFood()
    {
        var isActive = foodComm.activeSelf;

        if(handMoneyChanger.isFoodPriceInHandMoney() && !isActive)
        {
            foodComm.SetActive(true);
        }
        else if(isActive)
        {
            foodComm.SetActive(false);
        }
    }

    public void SetAnimal()
    {
        var isActive = animalComm.activeSelf;

        if(handMoneyChanger.isAnimalPriceInHandMoney() && !isActive)
        {
            animalComm.SetActive(true);
        }
        else if(isActive)
        {
            animalComm.SetActive(false);
        }
    }
}