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

    FoodStatus foodStatus;

    public float handMoney;
    
    void Awake()
    {
        handMoney = GameObject.Find("Player").GetComponent<PlayerStatusManager>().HandMoney;
        handMoneyText.GetComponent<Text>().text = handMoney.ToString() + "z";

        foodStatus = GameObject.Find("FoodList").GetComponent<FoodStatus>();
        
        SoundManager.Instance.PlayBGM((int)BGMList.SHOP);
    }

    // ホームボタン
    public void PushHome()
    {
        SoundManager.Instance.PlaySE((int)SEList.OK);
        SoundManager.Instance.StopBGM();
        
        SceneManager.LoadScene("GameMain");
    }

    //Debug
    public void FoodPossessionReset()
    {
        foodStatus.ResetPossession();
    }

    // Debug
    public void PurchaseResetAnimal()
    {
        for (int i = 0; i < 17; ++i)
        {
            GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[i].GetComponent<AnimalStatusManager>().status.IsPurchase = false;
        }
        GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().Save();
    }

    // エントランスの動物一覧ボタン
    public void PushAnimalButton()
    {
        SoundManager.Instance.PlaySE((int)SEList.OK);

        GameObject.Find("AnimalButtonController").GetComponent<AnimalButtonController>().Boughter();

        shopLabel.SetActive(false);
        animalButton.SetActive(false);
        foodButton.SetActive(false);
        MiddleTwine.SetActive(false);
        BottomTwine.SetActive(false);

        animalBoard.SetActive(true);
        animalBoardLabel.SetActive(true);
    }

    // 動物一覧画面の動物ボタン
    public void PushAnimal()
    {
        SoundManager.Instance.PlaySE((int)SEList.OK);

        animalBoard.SetActive(false);
        UpperTwine.SetActive(false);

        animalBuyWindow.SetActive(true);
    }

    // エントランスのご飯一覧ボタン
    public void PushFoodButton()
    {
        SoundManager.Instance.PlaySE((int)SEList.OK);

        shopLabel.SetActive(false);
        animalButton.SetActive(false);
        foodButton.SetActive(false);
        MiddleTwine.SetActive(false);
        BottomTwine.SetActive(false);

        foodShelf.SetActive(true);
        foodShelfLabel.SetActive(true);
    }

    // ご飯一覧画面のご飯ボタン
    public void PushFood()
    {
        SoundManager.Instance.PlaySE((int)SEList.OK);

        foodShelf.SetActive(false);
        UpperTwine.SetActive(false);

        foodBuyWindow.SetActive(true);
    }

    // 動物一覧画面のバツボタン
    public void CancelAnimalBoard()
    {
        SoundManager.Instance.PlaySE((int)SEList.CLOSE);

        shopLabel.SetActive(true);
        animalButton.SetActive(true);
        foodButton.SetActive(true);
        MiddleTwine.SetActive(true);
        BottomTwine.SetActive(true);

        animalBoard.SetActive(false);
    }

    // ご飯一覧画面のバツボタン
    public void CancelFoodShelf()
    {
        SoundManager.Instance.PlaySE((int)SEList.CLOSE);

        shopLabel.SetActive(true);
        animalButton.SetActive(true);
        foodButton.SetActive(true);
        MiddleTwine.SetActive(true);
        BottomTwine.SetActive(true);

        foodShelf.SetActive(false);
    }
}