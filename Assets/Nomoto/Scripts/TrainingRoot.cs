using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO;

public class TrainingRoot : MonoBehaviour
{
    [SerializeField]
    Image animalmage = null;

    [SerializeField]
    GameObject EatBoard = null;

    [SerializeField]
    Text TalkText = null;

    [SerializeField]
    CutTextureManager HeartManager = null;

    [SerializeField]
    CutTextureManager EatManager = null;

    [SerializeField]
    RectTransform popPosition = null;

    [SerializeField]
    GameObject Heart = null;

    [SerializeField]
    float[] MeetNums;
    [SerializeField]
    Text[] MeetTexts = null;

    [SerializeField]
    float[] VegetableNums;
    [SerializeField]
    Text[] VegetableTexts = null;

    private bool isSelectButton = false;

    public int satietyLelel = 0;
    public int maxSatietyLevel = 0;

    public int loveLevel = 0;
    public int maxLoveLevel = 0;

    int foodType = 0;

    private bool isAnimation = false;

    enum Type
    {
        NONE,
        EAT,
        BRUSH,
        TALK,
        COMMENT,
        FOOD_COMMENT
    }

    enum FoodCommentType
    {
        NONE,
        LIKE,
        DONT_LIKE
    }

    FoodCommentType foodCommentType = FoodCommentType.NONE;

    Type animationType = Type.NONE;

    [SerializeField]
    GameObject Brush = null;

    Vector3 BrushPos;

    int brusPoint = 0;

    float BrushTime = 0.0f;
    Vector3 prevMousePosition = Vector3.zero;

    [SerializeField]
    GameObject Food = null;

    Vector3 FoodSize;

    [SerializeField]
    GameObject CommentBoard = null;

    float animationTime = 0.0f;

    [SerializeField]
    GameObject Moya = null;

    Vector2 moyaSize;

    private FoodList foodList = null;


    private string[] talkComment = new string[4];

    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private int height = 0; // CSVの行数
    int selectNum;

    [SerializeField]
    Sprite[] FoodSprite = null;

    [SerializeField]
    Sprite[] VegetableSprite = null;

    [SerializeField]
    GameObject explanationFoodBoard = null;
    [SerializeField]
    Image explanationFoodSprite = null;

    [SerializeField]
    Text explanationFoodText = null;

    [SerializeField]
    string[] explanationFoodStr = new string[6];

    private int selectFoodType = 0;

    private float heartMakeTime = 0.0f;
    int rarity = 0;
    void Start()
    {
        explanationFoodStr[0] = "\nみんな大好き\n  赤身ステーキ!!";
        explanationFoodStr[1] = "いろんなものが\n  したたっている\n  ワイルドなご飯";
        explanationFoodStr[2] = "\n最高級品を追求した\n  全肉食動物が\n  うっとりする一品";
        explanationFoodStr[3] = "\nみんな大好き!!\n  赤いリンゴのご飯";
        explanationFoodStr[4] = "\n南国に行った\n   気分になれる\n  ハッピーなご飯";
        explanationFoodStr[5] = "\n最高級品を追求した\n  全草食動物が\n  うっとりする一品";

        Sound.PlayBgm("GameMainBgm");

        selectNum = GameObject.Find("AnimalList").GetComponent<SelectAnimalNum>().SelectNum;

        Debug.Log("Select : " + selectNum.ToString());
        animalmage.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[selectNum][0];

        ReadTalkComment();

        AnimalStatusManager animalStatusManager
            = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[selectNum].GetComponent<AnimalStatusManager>();

        foodList = GameObject.Find("FoodList").GetComponent<FoodList>();


        loveLevel = (int)animalStatusManager.status.LoveDegree;
        satietyLelel = (int)animalStatusManager.status.SatietyLevel;


        rarity = animalStatusManager.status.Rarity;
        maxLoveLevel = rarity * 20;
        maxSatietyLevel = rarity * 20;

        BrushPos = Brush.GetComponent<RectTransform>().position;
        FoodSize = Food.GetComponent<RectTransform>().sizeDelta;
        moyaSize = Moya.GetComponent<RectTransform>().sizeDelta;

        for (int i = 0; i < 3; ++i)
            MeetNums[i] = foodList.foodList[i].possessionNumber + 10;


        for (int i = 3; i < 6; ++i)
            VegetableNums[i - 3] = foodList.foodList[i].possessionNumber + 10;

        SetFoodText();
        EatManager.Change(satietyLelel, maxSatietyLevel);
        HeartManager.Change(loveLevel, maxLoveLevel);
    }

    private void Save()
    {
        GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[selectNum].GetComponent<AnimalStatusManager>().status.SatietyLevel = satietyLelel;
        GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[selectNum].GetComponent<AnimalStatusManager>().status.LoveDegree = loveLevel;
    }

    void ReadTalkComment()
    {
        csvFile = Resources.Load("AnimalComment/AnimalTalk" + selectNum.ToString()) as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); // リストに入れる
            height++; // 行数加算
        }

        for (int i = 0; i < 4; ++i)
        {
            talkComment[i] = csvDatas[0][i];
        }

    }

    void MakeHeart(int makeNum)
    {
        for (int i = 0; i < makeNum; ++i)
        {
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-20, 20), UnityEngine.Random.Range(-30, 30), 1);
            GameObject obj = Instantiate(Heart,
                                         new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            obj.transform.SetParent(GameObject.Find("Canvas").transform);
            Vector3 tempPos = new Vector3(screenSize.x * 3.0f / 4.5f
                                       + UnityEngine.Random.Range(-screenSize.x / 10.0f, screenSize.x / 10.0f),
                                       screenSize.y * 6.0f / 10.0f
                                       + +UnityEngine.Random.Range(-screenSize.x / 10.0f, screenSize.x / 10.0f),
                                       0);
            obj.GetComponent<RectTransform>().position = tempPos;
            obj.GetComponent<RectTransform>().sizeDelta = new Vector2(screenSize.x / 20.0f, screenSize.x / 20.0f);
            obj.GetComponent<MoveHeart>().Make();
        }
    }

    void Update()
    {

        UpdateBrush();
        UpdateEat();
        UpdateComment();
    }

    void UpdateBrush()
    {
        if (isAnimation != true) return;
        if (animationType != Type.BRUSH) return;
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 prevMousePos = new Vector2(prevMousePosition.x, prevMousePosition.y);
        if (Brush.GetComponent<DragMover>().IsDragging == true)
        {
            if (prevMousePos != mousePosition)
            {
                RectTransform myTransform = Brush.GetComponent<RectTransform>();
                Rect rect = new Rect(myTransform.position.x, myTransform.position.y, myTransform.rect.width, myTransform.rect.height);

                if (rect.position.x <= mousePosition.x && mousePosition.x <= rect.position.x + rect.width &&
                    rect.position.y <= mousePosition.y && mousePosition.y <= rect.position.y + rect.height)
                {
                    BrushTime += Time.deltaTime;
                    prevMousePosition = new Vector3(mousePosition.x, mousePosition.y,0);
                }   
            }
        }
        Debug.Log(BrushTime);
        if (BrushTime < 3.5f) return;
        animationType = Type.COMMENT;
        Brush.GetComponent<RectTransform>().position = BrushPos;
        BrushTime = 0.0f;
        Brush.SetActive(false);
        CommentBoard.SetActive(true);
        MakeHeart(2);
        foodCommentType = FoodCommentType.LIKE;
        Brush.GetComponent<RectTransform>().position = BrushPos;
        Brush.GetComponent<DragMover>().IsDragging = false;

        if (loveLevel + 1 <= maxLoveLevel)
        {
            loveLevel += 1;
            HeartManager.SetAnimation(loveLevel - 1, loveLevel, maxLoveLevel);
        }
    }

    void UpdateEat()
    {
        if (isAnimation != true) return;
        if (animationType != Type.EAT) return;
        animationTime += Time.deltaTime;

        if (Food.GetComponent<RectTransform>().sizeDelta.x > 0)
        {
            Food.GetComponent<RectTransform>().sizeDelta -= new Vector2(0.5f, 0.5f);
        }

        if (animationTime < 2.5f) return;
        animationTime = 0.0f;
        animationType = Type.COMMENT;
        Food.GetComponent<RectTransform>().sizeDelta = FoodSize;
        Food.SetActive(false);
        CommentBoard.SetActive(true);

        if (foodCommentType == FoodCommentType.LIKE)
        {
            MakeHeart(2);
        }
        else if (foodCommentType == FoodCommentType.DONT_LIKE)
        {
            Moya.SetActive(true);
        }
    }

    void UpdateComment()
    {
        if (isAnimation != true) return;
        if (animationType != Type.COMMENT) return;
        animationTime += Time.deltaTime;

        if (foodCommentType == FoodCommentType.LIKE)
        {
            heartMakeTime += Time.deltaTime;
            if (heartMakeTime > 0.5f)
            {
                heartMakeTime = 0.0f;
                MakeHeart(2);
            }
        }
        else if (foodCommentType == FoodCommentType.DONT_LIKE)
        {
            Moya.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 0.4f);
        }

        if (animationTime < 2.5f) return;
        animationTime = 0.0f;
        isAnimation = false;
        animationType = Type.NONE;
        CommentBoard.SetActive(false);
        isSelectButton = false;
        if (foodCommentType == FoodCommentType.DONT_LIKE)
        {
            Moya.SetActive(false);
            Moya.GetComponent<RectTransform>().sizeDelta = moyaSize;
            foodCommentType = FoodCommentType.NONE;
        }

        else if (foodCommentType == FoodCommentType.LIKE)
        {
            heartMakeTime = 0.0f;
            foodCommentType = FoodCommentType.NONE;
        }
    }

    void SetFoodText()
    {
        for (int i = 0; i < 3; ++i)
        {
            MeetTexts[i].text = "x " + MeetNums[i].ToString();
            VegetableTexts[i].text = "x " + VegetableNums[i].ToString();
        }
    }

    public void PushEatButton()
    {
        if (isSelectButton == true) return;
        isSelectButton = true;
        EatBoard.SetActive(true);
    }

    public void PushBrushButton()
    {
        if (isSelectButton == true) return;
        isSelectButton = true;
        TalkText.text = talkComment[0];

        isAnimation = true;
        animationType = Type.BRUSH;
        Brush.SetActive(true);
    }

    public void PushTalkButton()
    {
        if (isSelectButton == true) return;
        isSelectButton = true;
        int beforeLoveLevel = loveLevel; 
        loveLevel += rarity;
        if (loveLevel > maxLoveLevel)
            loveLevel = maxLoveLevel;
        int nowLoveLevel = loveLevel;

        HeartManager.SetAnimation(beforeLoveLevel, nowLoveLevel, maxLoveLevel);

        TalkText.text = talkComment[1];
        isAnimation = true;
        animationType = Type.COMMENT;
        CommentBoard.SetActive(true);
    }

    public void PushBackHomeButton()
    {
        Save();
        GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().Save();
        Sound.StopBgm();
    }

    public void PushOfBackEatBoard()
    {
        isSelectButton = false;
        EatBoard.SetActive(false);
    }


    public void PushAnswer(int num)
    {
        if (num == 0)
        {
            switch (selectFoodType)
            {
                case 0:
                    PushMeatType(0);
                    break;
                case 1:
                    PushMeatType(1);
                    break;
                case 2:
                    PushMeatType(2);
                    break;
                case 3:
                    PushVegetableType(0);
                    break;
                case 4:
                    PushVegetableType(1);
                    break;
                case 5:
                    PushVegetableType(2);
                    break;
            }

        }

        explanationFoodBoard.SetActive(false);
    }

    public void PushFoodTypeNum(int num)
    {
        selectFoodType = num;
        explanationFoodText.text = explanationFoodStr[num];

        if (num < 3)
            explanationFoodSprite.sprite = FoodSprite[num];
        else
            explanationFoodSprite.sprite = VegetableSprite[num - 3];

        explanationFoodBoard.SetActive(true);
    }

    public void PushMeatType(int choiseFoodRank)
    {
        if (MeetNums[choiseFoodRank] == 0) return;
        --MeetNums[choiseFoodRank];
        SetFoodText();

        Food.GetComponent<Image>().sprite = FoodSprite[choiseFoodRank];

        if (foodType == 0)
        {
            foodCommentType = FoodCommentType.LIKE;

            TalkText.text = talkComment[2];
            switch (choiseFoodRank)
            {
                case 0:
                    satietyLelel += 1;
                    break;
                case 1:
                    satietyLelel += 2;
                    loveLevel += 1;
                    break;
                case 2:
                    satietyLelel += 3;
                    loveLevel += 2;
                    break;
            }
        }

        else
        {
            foodCommentType = FoodCommentType.DONT_LIKE;
            TalkText.text = talkComment[3];
        }
        if (satietyLelel > maxSatietyLevel)
            satietyLelel = maxSatietyLevel;
        if (loveLevel > maxLoveLevel)
            loveLevel = maxLoveLevel;
        EatManager.Change(satietyLelel, maxSatietyLevel);
        EatBoard.SetActive(false);
        Food.SetActive(true);
        isAnimation = true;
        animationType = Type.EAT;
    }

    public void PushVegetableType(int choiseFoodRank)
    {
        if (VegetableNums[choiseFoodRank] == 0) return;
        --VegetableNums[choiseFoodRank];
        SetFoodText();

        Food.GetComponent<Image>().sprite = VegetableSprite[choiseFoodRank];

        if (foodType == 1)
        {
            foodCommentType = FoodCommentType.LIKE;
            TalkText.text = talkComment[2];
            switch (choiseFoodRank)
            {
                case 0:
                    satietyLelel += 1;
                    break;
                case 1:
                    satietyLelel += 2;
                    loveLevel += 1;
                    break;
                case 2:
                    satietyLelel += 3;
                    loveLevel += 2;
                    break;
            }
        }
        else
        {
            foodCommentType = FoodCommentType.DONT_LIKE;
            TalkText.text = talkComment[3];
        }
        if (satietyLelel > maxSatietyLevel)
            satietyLelel = maxSatietyLevel;
        if (loveLevel > maxLoveLevel)
            loveLevel = maxLoveLevel;
        EatManager.Change(satietyLelel, maxSatietyLevel);
        EatBoard.SetActive(false);
        Food.SetActive(true);
        isAnimation = true;
        animationType = Type.EAT;
    }
}