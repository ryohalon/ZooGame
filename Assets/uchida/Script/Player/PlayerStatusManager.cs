using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class PlayerStatusManager : MonoBehaviour
{
    // 来場者一人当たりの入園料(固定)
    public int entranceFee = 20;

    private Timer timer = null;

    // 動物の檻のリスト
    private AnimalStatusCSV animalStatusCSV = null;
    private CombManager combManager = null;

    static private PlayerStatusManager instance = null;

    // 動物園の名前
    // これがないとモチベが上がらんしょ
    public string ZooName { get; set; }
    // ストーリーの進行度
    // 達成したときに次の目標金額を設定するときに使うかも
    public int StoryLevel { get; set; }
    // 所持金
    public float HandMoney { get; set; }
    // 目標金額
    public float TargetMoney { get; set; }

    // その日に稼いだ金額
    public float OneDayEarnedMoney { get; set; }
    // その日に使用した金額
    public float OneDayUsedMoney { get; set; }
    // その日に来場した客のかず
    public float OneDayVisitors { get; set; }
    // その日にフードに使用した金額
    public float OneDayFoodCost { get; set; }
    // その日に動物購入で使用した金額
    public float OneDayAnimalPurchaseCost { get; set; }
    // その日におもちゃで使用した金額
    public float OneDayToyCost { get; set; }

    // 今までに稼いだ総金額
    public float TotalMoney { get; set; }
    // 今までに使った総金額
    public float TotalUsedMoney { get; set; }
    // 今までの総来場者数
    public float TotalVisitors { get; set; }
    // 所持している動物の数
    public int AnimalNum { get; set; }
    // 愛情度をMAXにした動物の数
    public int MaxLoveDegreeAnimalNum { get; set; }



    FileInfo playerFile = null;


    // 目標までの残り金額
    public int GetMoneyToTheTarget()
    {
        return ((TargetMoney - HandMoney) >= 0) ?
            (int)(TargetMoney - HandMoney) : 0;
    }



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
        playerFile = new FileInfo(Application.dataPath + "/uchida/resource/Text/playerStatus.csv");
        try
        {
            using (StreamReader sr = new StreamReader(playerFile.Open(FileMode.Open, FileAccess.Read)))
            {
                string txt = sr.ReadToEnd();

                string[] playerStatus = txt.Split(',');

                ZooName = playerStatus[0];
                StoryLevel = int.Parse(playerStatus[1]);
                HandMoney = float.Parse(playerStatus[2]);
                TargetMoney = float.Parse(playerStatus[3]);
                OneDayEarnedMoney = float.Parse(playerStatus[4]);
                OneDayUsedMoney = float.Parse(playerStatus[5]);
                OneDayVisitors = float.Parse(playerStatus[6]);
                OneDayFoodCost = float.Parse(playerStatus[7]);
                OneDayAnimalPurchaseCost = float.Parse(playerStatus[8]);
                OneDayToyCost = float.Parse(playerStatus[9]);
                TotalMoney = float.Parse(playerStatus[10]);
                TotalUsedMoney = float.Parse(playerStatus[11]);
                TotalVisitors = float.Parse(playerStatus[12]);
                AnimalNum = int.Parse(playerStatus[13]);
                MaxLoveDegreeAnimalNum = int.Parse(playerStatus[14]);


                foreach(var p in playerStatus)
                {
                    Debug.Log(p);
                }
            }
        }
        catch (Exception e)
        {

        }
    }

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        timer = GameObject.Find("Timer").GetComponent<Timer>();
        var animalList = GameObject.Find("AnimalList");
        animalStatusCSV = animalList.GetComponent<AnimalStatusCSV>();
        combManager = animalList.GetComponent<CombManager>();

        LoadStatus();
    }

    void Start()
    {
        StartCoroutine(UpdatePlayerStatus());
    }

    // 毎フレーム行うお金が増えてく処理
    private IEnumerator UpdatePlayerStatus()
    {
        while (true)
        {
            if (!timer.isEndDay)
            {
                GetElapsedTimeVisitors(Time.deltaTime);
            }

            yield return null;
        }
    }

    // 経過時間でやってきたお客さんの総数
    public void GetElapsedTimeVisitors(float elapsedTime)
    {
        var animalList = animalStatusCSV.animals;

        float totalVisitors = 0;
        foreach (var animal in animalList)
        {
            var animalStatus = animal.GetComponent<AnimalStatusManager>();
            if (animalStatus.status.CageID == -1)
                continue;

            totalVisitors += animalStatus.GetVisitors(elapsedTime);
        }

        float totalVisitors_ = totalVisitors * combManager.totalComboRate;
        float earnedMoney = entranceFee * totalVisitors_;

        OneDayEarnedMoney += earnedMoney;
        OneDayVisitors += totalVisitors_;
        TotalMoney += earnedMoney;
        TotalVisitors += totalVisitors_;
    }



    public void OnApplicationQuit()
    {
        StreamWriter sw = new StreamWriter(playerFile.Open(FileMode.Open, FileAccess.Write));

        sw.WriteLine(ZooName +
            "," + StoryLevel +
            "," + HandMoney +
            "," + TargetMoney +
            "," + OneDayEarnedMoney +
            "," + OneDayUsedMoney +
            "," + OneDayVisitors +
            "," + OneDayFoodCost +
            "," + OneDayAnimalPurchaseCost +
            "," + OneDayToyCost +
            "," + TotalMoney +
            "," + TotalUsedMoney +
            "," + TotalVisitors +
            "," + AnimalNum +
            "," + MaxLoveDegreeAnimalNum);
        sw.Flush();
        sw.Close();
    }

}
