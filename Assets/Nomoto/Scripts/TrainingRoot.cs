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
    GameObject HomeButton = null;

    [SerializeField]
    GameObject EatButton = null;

    [SerializeField]
    GameObject EatBoard = null;

    [SerializeField]
    GameObject BrushButton = null;

    [SerializeField]
    GameObject TalkButton = null;

    [SerializeField]
    Text NameText = null;

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

    Vector3 BrushMoveSpeed;

    int BrushCount = 1;

    float BrushTime = 0.0f;

    [SerializeField]
    GameObject Food = null;

    [SerializeField]
    Sprite[] foodImage = null;

    Vector3 FoodPos;

    Vector3 FoodSize;

    float FoodTime = 0.0f;

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

    void Start()
    {
        Sound.PlayBgm("GameMainBgm");

      //  GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().Read();

        selectNum = GameObject.Find("AnimalList").GetComponent<SelectAnimalNum>().SelectNum;

        Debug.Log("Select : " + selectNum.ToString());
        animalmage.sprite = GameObject.Find("AnimalList").GetComponent<AnimalTextureManager>().animalTextureList[selectNum][0];

        ReadTalkComment();

        AnimalStatusManager animalStatusManager
            = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals[selectNum].GetComponent<AnimalStatusManager>();

        foodList = GameObject.Find("FoodList").GetComponent<FoodList>();


        loveLevel = (int)animalStatusManager.status.LoveDegree;
        satietyLelel = (int)animalStatusManager.status.SatietyLevel;

        int rarity = animalStatusManager.status.Rarity;
        maxLoveLevel = rarity * 20;
        maxSatietyLevel = rarity * 20;

        BrushPos = Brush.GetComponent<RectTransform>().position;
        BrushMoveSpeed = new Vector3(-70, -10, 0);
        FoodPos = Food.GetComponent<RectTransform>().position;
        FoodSize = Food.GetComponent<RectTransform>().sizeDelta;
        moyaSize = Moya.GetComponent<RectTransform>().sizeDelta;

        for (int i = 0; i < 3; ++i)
            MeetNums[i] = foodList.foodList[i].possessionNumber + 10;


        for (int i = 3; i < 6; ++i)
            VegetableNums[i - 3] = foodList.foodList[i].possessionNumber + 10;

        SetFoodText();
        EatManager.Change(satietyLelel, maxSatietyLevel);
        HeartManager.Change(loveLevel,maxSatietyLevel);
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

    void Update()
    {

        if (isAnimation == true)
        {
            if (animationType == Type.BRUSH)
            {
                Brush.GetComponent<RectTransform>().position += BrushMoveSpeed * Time.deltaTime;

                if (0.6f * BrushCount < BrushTime)
                {
                    BrushMoveSpeed *= -1;
                    ++BrushCount;
                }

                BrushTime += Time.deltaTime;

                if (BrushTime > 3.5f)
                {
                    animationType = Type.COMMENT;
                    Brush.GetComponent<RectTransform>().position = BrushPos;
                    BrushTime = 0.0f;
                    Brush.SetActive(false);
                    CommentBoard.SetActive(true);

                    for (int i = 0; i < 10; ++i)
                    {
                        Vector3 pos = new Vector3(UnityEngine.Random.Range(-20, 20), UnityEngine.Random.Range(-30, 30), 1);
                        GameObject obj = Instantiate(Heart,
                                                     new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        obj.transform.SetParent(GameObject.Find("Canvas").transform);
                        obj.GetComponent<RectTransform>().position = popPosition.position + pos;
                        obj.GetComponent<MoveHeart>().Make();
                    }

                    Brush.GetComponent<RectTransform>().position = BrushPos;
                    BrushMoveSpeed = new Vector3(-70, -10, 0);
                    BrushCount = 1;
                }

            }

            else if (animationType == Type.EAT)
            {
                animationTime += Time.deltaTime;

                if (Food.GetComponent<RectTransform>().sizeDelta.x > 0)
                {
                    Food.GetComponent<RectTransform>().sizeDelta -= new Vector2(0.5f, 0.5f);
                }

                if (animationTime > 2.5f)
                {
                    animationTime = 0.0f;
                    animationType = Type.COMMENT;
                    Food.GetComponent<RectTransform>().sizeDelta = FoodSize;
                    Food.SetActive(false);
                    CommentBoard.SetActive(true);

                    if (foodCommentType == FoodCommentType.LIKE)
                    {
                        for (int i = 0; i < 10; ++i)
                        {
                            Vector3 pos = new Vector3(UnityEngine.Random.Range(-20, 20), UnityEngine.Random.Range(-30, 30), 1);
                            GameObject obj = Instantiate(Heart,
                                                         new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                            obj.transform.SetParent(GameObject.Find("Canvas").transform);
                            obj.GetComponent<RectTransform>().position = popPosition.position + pos;
                            obj.GetComponent<MoveHeart>().Make();
                        }
                    }

                    else if (foodCommentType == FoodCommentType.DONT_LIKE)
                    {
                        Moya.SetActive(true);
                    }
                }
            }

            else if (animationType == Type.COMMENT)
            {
                animationTime += Time.deltaTime;

                if (foodCommentType == FoodCommentType.DONT_LIKE)
                {
                    Moya.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 0.4f);
                }
                if (animationTime > 2.5f)
                {
                    animationTime = 0.0f;
                    isAnimation = false;
                    animationType = Type.NONE;
                    CommentBoard.SetActive(false);
                    isSelectButton = false;
                    SetActiveButton(true);
                    if (foodCommentType == FoodCommentType.DONT_LIKE)
                    {
                        Moya.SetActive(false);
                        Moya.GetComponent<RectTransform>().sizeDelta = moyaSize;
                        foodCommentType = FoodCommentType.NONE;
                    }
                }
            }
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

    void SetActiveButton(bool active)
    {
        //EatButton.SetActive(active);
        //BrushButton.SetActive(active);
        //TalkButton.SetActive(active);
        //HomeButton.SetActive(active);
    }

    public void PushEatButton()
    {
        if (isSelectButton == true) return;
        isSelectButton = true;
        SetActiveButton(false);
        EatBoard.SetActive(true);
    }

    public void PushBrushButton()
    {
        if (isSelectButton == true) return;
        isSelectButton = true;
        SetActiveButton(false);

        if (loveLevel + 1 <= maxLoveLevel)
            loveLevel += 1;
        HeartManager.Change(loveLevel, maxLoveLevel);
        TalkText.text = talkComment[0];

        isAnimation = true;
        animationType = Type.BRUSH;
        Brush.SetActive(true);
    }

    public void PushTalkButton()
    {
        if (isSelectButton == true) return;
        isSelectButton = true;
        SetActiveButton(false);
        loveLevel += 10;

        if (loveLevel > maxLoveLevel)
            loveLevel = maxLoveLevel;
        HeartManager.Change(loveLevel, maxLoveLevel);

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
        SetActiveButton(true);
        EatBoard.SetActive(false);
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
        //Food.GetComponent<Image>().sprite = foodImage[0];
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
        //Food.GetComponent<Image>().sprite = foodImage[1];
        isAnimation = true;
        animationType = Type.EAT;
    }


}
