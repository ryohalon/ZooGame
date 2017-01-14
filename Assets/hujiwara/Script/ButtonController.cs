using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void PushHome()
    {
        Sound.PlaySe("Ok");
        SceneManager.LoadScene("GameMain");
    }

    public void PurchaseResetAnimal()
    {
        for (int i = 0; i < 17; ++i)
        {
            GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[i].GetComponent<AnimalStatusManager>().status.IsPurchase = false;
        }
    }

    public void PushAnimalButton()
    {
        Sound.PlaySe("Ok");

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
        Sound.PlaySe("Ok");

        animalBoard.SetActive(false);
        UpperTwine.SetActive(false);

        animalBuyWindow.SetActive(true);
    }

    public void PushFoodButton()
    {
        Sound.PlaySe("Ok");

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
        Sound.PlaySe("Ok");

        foodShelf.SetActive(false);
        UpperTwine.SetActive(false);

        foodBuyWindow.SetActive(true);
    }

    public void CancelAnimalBoard()
    {
        Sound.PlaySe("Close");

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