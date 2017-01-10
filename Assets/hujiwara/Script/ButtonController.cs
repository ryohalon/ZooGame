using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject handMoneyText = null;

    [SerializeField]
    GameObject animalButton = null;

    [SerializeField]
    GameObject foodButton = null;

    [SerializeField]
    GameObject shopLabel = null;

    [SerializeField]
    GameObject animalBoard = null;

    [SerializeField]
    GameObject animalBoardLabel = null;

    [SerializeField]
    GameObject animalBuyWindow = null;

    [SerializeField]
    GameObject foodShelf = null;

    [SerializeField]
    GameObject foodShelfLabel = null;

    [SerializeField]
    GameObject foodBuyWindow = null;

    [SerializeField]
    GameObject UpperTwine = null;

    [SerializeField]
    GameObject MiddleTwine = null;

    [SerializeField]
    GameObject BottomTwine = null;

    public float handMoney;
    
    void Awake()
    {
        handMoney = GameObject.Find("Player").GetComponent<PlayerStatusManager>().HandMoney;
        handMoneyText.GetComponent<Text>().text = handMoney.ToString() + "z";
        Sound.PlayBgm("ShopBgm");
    }

    public void PushAnimalButton()
    {
        GameObject.Find("AnimalButtonController").GetComponent<AnimalButtonController>().Boughter();

        shopLabel.SetActive(false);
        animalButton.SetActive(false);
        foodButton.SetActive(false);
        MiddleTwine.SetActive(false);
        BottomTwine.SetActive(false);

        animalBoard.SetActive(true);
        animalBoardLabel.SetActive(true);
    }

    public void PushAnimal()
    {
        animalBoard.SetActive(false);
        UpperTwine.SetActive(false);

        animalBuyWindow.SetActive(true);
    }

    public void PushAnimalNoButton()
    {
        animalBuyWindow.SetActive(false);

        animalBoard.SetActive(true);
        UpperTwine.SetActive(true);
    }

    public void PushFoodButton()
    {
        shopLabel.SetActive(false);
        animalButton.SetActive(false);
        foodButton.SetActive(false);
        MiddleTwine.SetActive(false);
        BottomTwine.SetActive(false);

        foodShelf.SetActive(true);
        foodShelfLabel.SetActive(true);
    }

    public void PushFood()
    {
        foodShelf.SetActive(false);
        UpperTwine.SetActive(false);

        foodBuyWindow.SetActive(true);
    }

    public void CancelAnimalBoard()
    {
        shopLabel.SetActive(true);
        animalButton.SetActive(true);
        foodButton.SetActive(true);
        MiddleTwine.SetActive(true);
        BottomTwine.SetActive(true);

        animalBoard.SetActive(false);
    }

    public void CancelFoodShelf()
    {
        Sound.PlaySe("Close");
        shopLabel.SetActive(true);
        animalButton.SetActive(true);
        foodButton.SetActive(true);
        MiddleTwine.SetActive(true);
        BottomTwine.SetActive(true);

        foodShelf.SetActive(false);
    }
}