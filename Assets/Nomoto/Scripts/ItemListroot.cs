using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;

public class ItemListroot : MonoBehaviour
{
    [SerializeField]
    GameObject FoodBinder = null;

    [SerializeField]
    GameObject FoodText = null;

    [SerializeField]
    Image FoodImage = null;

    [SerializeField]
    GameObject foodExplanationView = null;

    [SerializeField]
    GameObject AnimalBinder = null;

    [SerializeField]
    GameObject FoodList = null;

    [SerializeField]
    GameObject AnimalList = null;

    [SerializeField]
    Text[] foodNumText = null;

    [SerializeField]
    Text foodExplanation = null;

    [SerializeField]
    Sprite[] foodSprite = null;

    private string[] foodExplanationText = new string[6];

    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private int height = 0; // CSVの行数

    private FoodList foodList = null;

    void Start()
    {
        foodList = GameObject.Find("FoodList").GetComponent<FoodList>();

        for (int i = 0; i < 6; ++i)
            foodNumText[i].text = "X " + foodList.foodList[i].possessionNumber.ToString();

        foodExplanationText[0] = "\n  みんな大好き\n          赤身ステーキ!!";
        foodExplanationText[1] = "\n  産地直送で\n  いろんなものが\n  したたっている\n  ワイルドなご飯";
        foodExplanationText[2] = "\n  最高級品を追求した\n  全肉食動物が\n  うっとりする一品";
        foodExplanationText[3] = "\n  みんな大好き!!\n  赤いリンゴのご飯";
        foodExplanationText[4] = "\n  南国に行った\n          気分になれる\n  ハッピーなご飯";
        foodExplanationText[5] = "\n  最高級品を追求した\n  全草食動物が\n  うっとりする一品";
    }

    public void PushFood()
    {
        FoodList.SetActive(true);
    }

    public void PushAnimal()
    {
        AnimalList.SetActive(true);
    }

    public void PushCancelButton()
    {
        AnimalList.SetActive(false);
        FoodList.SetActive(false);
        foodExplanationView.SetActive(false);
    }

    public void PushFoodExplanation(int num)
    {
        foodExplanation.text = foodExplanationText[num];
        FoodImage.sprite = foodSprite[num];
        foodExplanationView.SetActive(true);
    }

    public void PushCancelFoodExplanation()
    {
        foodExplanationView.SetActive(false);
    }

    void Update()
    {

    }
}
