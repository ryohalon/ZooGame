using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerStatusManager : MonoBehaviour
{
    // 来場者一人当たりの入園料(固定)※今のところ
    public int entranceFee = 20;


    // 動物の檻のリスト
    [SerializeField]
    private GameObject AnimalListManager = null;

    // 動物園の名前
    // これがないとモチベが上がらんしょ
    public string ZooName { get; set; }
    // ストーリーの進行度
    // 達成したときに次の目標金額を設定するときに使うかも
    public int StoryLevel { get; set; }
    // 所持金
    public int HandMoney { get; set; }
    // 目標金額
    public int TargetMoney { get; set; }

    // その日に稼いだ金額
    public int OneDayEarnedMoney { get; set; }
    // その日に使用した金額
    public int OneDayUsedMoney { get; set; }
    // その日に来場した客のかず
    public int OneDayVisitors { get; set; }
    // その日にフードに使用した金額
    public int OneDayFoodCost { get; set; }
    // その日に動物購入で使用した金額
    public int OneDayAnimalPurchaseCost { get; set; }
    // その日におもちゃで使用した金額
    public int OneDayToyCost { get; set; }

    // 今までに稼いだ総金額
    public int TotalMoney { get; set; }
    // 今までに使った総金額
    public int TotalUsedMoney { get; set; }
    // 今までの総来場者数
    public int TotalVisitors { get; set; }
    // 所持している動物の数
    public int AnimalNum { get; set; }
    // 愛情度をMAXにした動物の数
    public int MaxLoveDegreeAnimalNum { get; set; }


    // 目標までの残り金額
    public int GetMoneyToTheTarget() {
        return ((TargetMoney - HandMoney) >= 0) ? 
            (TargetMoney - HandMoney) : 0;
    }

    

    // すべてリセット(仮)
    public void Reset()
    {
        entranceFee = 20;
        StoryLevel = 1;
        HandMoney = 0;
        TargetMoney = 0;
        ResetOneDay();
        TotalMoney = 0;
        TotalUsedMoney = 0;
        TotalVisitors = 0;
    }

    // 一日の間だけ加算する変数のリセット
    // 日が変わるときに呼ぶ
    public void ResetOneDay()
    {
        OneDayEarnedMoney = 0;
        OneDayUsedMoney = 0;
        OneDayVisitors = 0;
    }


    // 起動時に外部ファイルからデータを読み込む
    private void LoadStatus()
    {
        Debug.Log("まだ書いてない");
    }

    private void  DebugStatus()
    {
        OneDayFoodCost = 50000;
        OneDayAnimalPurchaseCost = 2000000;
        OneDayToyCost = 20000;
        OneDayVisitors = 560000;
    }


    void Start()
    {
        LoadStatus();

        DebugStatus();
        
        StartCoroutine(UpdatePlayerStatus());
    }

    // 毎フレーム行うお金が増えてく処理
    // 見てて一番面白いところ(わっち的に(笑))
    private IEnumerator UpdatePlayerStatus()
    {
        while(true)
        {
            int totalVisitors = GetElapsedTimeVisitors(Time.deltaTime);

            int earnedMoney = entranceFee * totalVisitors;

            HandMoney += earnedMoney;

            OneDayEarnedMoney += earnedMoney;
            OneDayVisitors += totalVisitors;

            TotalMoney += earnedMoney;
            TotalVisitors += totalVisitors;

            yield return null;
        }
    }

    // 経過時間でやってきたお客さんの総数
    private int GetElapsedTimeVisitors(float elapsedTime)
    {
        var animalList = AnimalListManager.GetComponent<AnimalListManager>().animalList;

        int totalVisitors = 0;
        foreach(var animal in animalList)
        {
            var animalStatus = animal.GetComponent<AnimalStatusManager>();
            if (animalStatus.status.CageID == 99)
                continue;

            totalVisitors += animalStatus.GetVisitors(elapsedTime);
        }

        return totalVisitors;
    }
}
