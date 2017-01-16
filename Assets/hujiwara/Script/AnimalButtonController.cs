using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimalButtonController : MonoBehaviour
{
    // 動物一覧画面
    [SerializeField]
    GameObject animalBoard = null;

    // 動物一覧上部看板
    [SerializeField]
    GameObject animalBoardLabel = null;

    [SerializeField]
    GameObject upperTwine = null;

    // 購入画面
    [SerializeField]
    GameObject animalBuyWindow = null;

    // 購入画面 動物名
    [SerializeField]
    GameObject animalNameText = null;

    // 購入画面 動物イメージ
    [SerializeField]
    GameObject animalImage = null;

    // 購入画面 動物値段
    [SerializeField]
    GameObject animalPriceText = null;

    // 所持金不足時表示テキスト
    [SerializeField]
    GameObject handMoneyMissingTextBoard = null;

    // 所持金
    [SerializeField]
    GameObject handMoneyText = null;

    // 購入時表示イラスト
    [SerializeField]
    GameObject buyCommentBoard = null;

    // 購入時コメント
    [SerializeField]
    GameObject buyCommentText = null;

    [SerializeField]
    GameObject peacockBought = null;

    [SerializeField]
    GameObject monkeyBought = null;

    [SerializeField]
    GameObject owlBought = null;

    [SerializeField]
    GameObject rhinoBought = null;

    [SerializeField]
    GameObject ponyBought = null;

    [SerializeField]
    GameObject flamingoBought = null;

    [SerializeField]
    GameObject wolfBought = null;

    [SerializeField]
    GameObject elephantBought = null;

    [SerializeField]
    GameObject hawkBought = null;

    [SerializeField]
    GameObject polarBearBought = null;

    [SerializeField]
    GameObject lesserPandaBought = null;

    [SerializeField]
    GameObject giraffeBought = null;

    [SerializeField]
    GameObject blackLeopardBought = null;

    [SerializeField]
    GameObject tigerBought = null;

    [SerializeField]
    GameObject pandaBought = null;

    // 動物イメージ用
    Image img;

    float handMoney;

    int animalPrice;

    float time;
    bool isShowText;

    bool isFirstComment;

    int ID;

    void Awake()
    {
        img = animalImage.GetComponent<Image>();
        handMoney = GameObject.Find("ButtonController").GetComponent<ButtonController>().handMoney;

        time = 2;
        isShowText = false;

        isFirstComment = true;
    }

    void Update()
    {
        if(isShowText)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                isShowText = false;
                handMoneyMissingTextBoard.SetActive(false);
                time = 2;
            }
        }
    }

    // 購入画面Noボタン
    public void PushNoButton()
    {
        SoundManager.Instance.PlaySE((int)SEList.CLOSE);

        animalBuyWindow.SetActive(false);

        animalBoard.SetActive(true);
        animalBoardLabel.SetActive(true);
        upperTwine.SetActive(true);
    }

    // 購入画面Yesボタン
    public void PushYesButton()
    {
        if(IsInPossessionMoney())
        {
            SoundManager.Instance.PlaySE((int)SEList.CASH);

            handMoney -= animalPrice;
            handMoneyText.GetComponent<Text>().text = handMoney.ToString();
            GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[ID].GetComponent<AnimalStatusManager>().status.IsPurchase = true;
            GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().Save();
            
            Boughter();

            CommentChanger();
            buyCommentBoard.SetActive(true);
        }
        else
        {
            SoundManager.Instance.PlaySE((int)SEList.CLOSE);

            handMoneyMissingTextBoard.SetActive(true);
            isShowText = true;
        }
    }

    public void PushNextButton()
    {
        SoundManager.Instance.PlaySE((int)SEList.OK);

        if (isFirstComment)
        {
            isFirstComment = false;
        }
        else
        {
            isFirstComment = true;
        }

        animalBuyWindow.SetActive(false);
        buyCommentBoard.SetActive(false);

        upperTwine.SetActive(true);
        animalBoardLabel.SetActive(true);
        animalBoard.SetActive(true);
    }

    void CommentChanger()
    {
        if (isFirstComment)
        {
            buyCommentText.GetComponent<Text>().text = "今日からよろしくね！";
        }
        else
        {
            buyCommentText.GetComponent<Text>().text = "一緒に頑張ろうね！";
        }
    }

    // 所持金内か
    bool IsInPossessionMoney()
    {
        if (handMoney >= animalPrice)
        {
            return true;
        }
        return false;
    }

    public void PushPeacock()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[0][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[0].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushMonkey()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[3][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[3].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushOwl()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[4][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[4].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushRhino()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[5][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[5].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushPony()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[6][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[6].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushFlamingo()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[7][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[7].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushWolf()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[8][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[8].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushElephant()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[9][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[9].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushHawk()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[10][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[10].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushPolarBear()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[11][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[11].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushLesserPanda()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[12][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[12].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushGiraffe()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[13][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[13].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushBlackLeopard()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[14][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[14].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushTiger()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[15][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[15].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    public void PushPanda()
    {
        img.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[16][0];

        ID = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[16].GetComponent<AnimalStatusManager>().status.ID;
        SetInformation(ID);
    }

    void SetInformation(int _ID)
    {
        SoundManager.Instance.PlaySE((int)SEList.OK);

        animalNameText.GetComponent<Text>().text =
            GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[_ID].GetComponent<AnimalStatusManager>().status.Name;

        animalPrice = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[_ID].GetComponent<AnimalStatusManager>().status.PurchasePrice;
        animalPriceText.GetComponent<Text>().text = animalPrice.ToString() + "z";
    }

    public void Boughter()
    {
        if(GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[0].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            peacockBought.SetActive(true);
        }
        else
        {
            peacockBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[3].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            monkeyBought.SetActive(true);
        }
        else
        {
            monkeyBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[4].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            owlBought.SetActive(true);
        }
        else
        {
            owlBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[5].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            rhinoBought.SetActive(true);
        }
        else
        {
            rhinoBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[6].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            ponyBought.SetActive(true);
        }
        else
        {
            ponyBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[7].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            flamingoBought.SetActive(true);
        }
        else
        {
            flamingoBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[8].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            wolfBought.SetActive(true);
        }
        else
        {
            wolfBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[9].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            elephantBought.SetActive(true);
        }
        else
        {
            elephantBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[10].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            hawkBought.SetActive(true);
        }
        else
        {
            hawkBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[11].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            polarBearBought.SetActive(true);
        }
        else
        {
            polarBearBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[12].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            lesserPandaBought.SetActive(true);
        }
        else
        {
            lesserPandaBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[13].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            giraffeBought.SetActive(true);
        }
        else
        {
            giraffeBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[14].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            blackLeopardBought.SetActive(true);
        }
        else
        {
            blackLeopardBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[15].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            tigerBought.SetActive(true);
        }
        else
        {
            tigerBought.SetActive(false);
        }

        if (GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[16].GetComponent<AnimalStatusManager>().status.IsPurchase == true)
        {
            pandaBought.SetActive(true);
        }
        else
        {
            pandaBought.SetActive(false);
        }
    }
}