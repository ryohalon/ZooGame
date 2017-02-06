using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class ResultManager : MonoBehaviour
{
    private Timer timer = null;
    private PlayerStatusManager player = null;
    private GameObject coin = null;
    private GameObject coinBox = null;
    [SerializeField]
    private GameObject colorFade = null;

    private int totalFoodCost = 0;
    private int totalAnimalPurchaseCost = 0;
    private int totalToyCost = 0;
    private int totalVisitors = 0;
    private int totalEntranceFee = 0;
    private int balanceOfPayments = 0;

    private float moveTakeTime = 0.5f;
    private bool isMoveEnd = false;

    private float time = 0.0f;
    private Easing easing;
    private bool isEasingEnd = false;

    public List<float> easingStart = new List<float>();
    public List<float> easingTakeTime = new List<float>();

    private float spawnTime = 0.0f;
    private float spawnTakeTime = 0.05f;

    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        player = GameObject.Find("Player").GetComponent<PlayerStatusManager>();

        easing = GetComponent<Easing>();
        coin = transform.GetChild(6).gameObject;
        coinBox = transform.GetChild(7).gameObject;

        StartCoroutine(UpdateResult());
    }

    private IEnumerator UpdateResult()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
                time = easingStart[easingStart.Count - 1] + easingTakeTime[easingTakeTime.Count - 1];

            if(!isMoveEnd)
                MoveWindow();
            else
            {
                UpdateEasing();
                UpdateText();
                SpawnCoin();

                GoNextDay();
            }

            yield return null;
        }
    }

    private void MoveWindow()
    {
        time += Time.deltaTime / moveTakeTime;
        transform.localPosition =
            new Vector3(
                easing.CircInOut(time, GetComponent<RectTransform>().rect.size.x / -2.0f, 0.0f),
                0.0f,
                0.0f);
        if (time < 1.0f)
            return;

        time = 0.0f;
        isMoveEnd = true;
    }

    private void SpawnCoin()
    {
        if (time < easingStart[5])
            return;
        if (totalEntranceFee - (totalFoodCost + totalAnimalPurchaseCost + totalToyCost) <= 0)
            return;
        if (isEasingEnd)
            return;

        spawnTime += Time.deltaTime;
        if (spawnTime < spawnTakeTime)
            return;

        spawnTime = 0.0f;
        spawnTakeTime = UnityEngine.Random.Range(0.01f, 0.1f);
        var coin_ = Instantiate(coin);
        coin_.transform.SetParent(coinBox.transform);
        coin_.AddComponent<CoinFaller>();
        coin_.AddComponent<Easing>();
    }

    private void GoNextDay()
    {
        if (!isEasingEnd)
            return;
        if (!Input.GetMouseButtonDown(0))
            return;

        SoundManager.Instance.PlaySE((int)SEList.CLOSE);

        var animalCSV = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().animals;
        foreach(var animal in animalCSV)
        {
            animal.GetComponent<AnimalStatusManager>().status.CommunicationNums = 1;
            animal.GetComponent<AnimalStatusManager>().status.MealNums = 1;
            animal.GetComponent<AnimalStatusManager>().status.BurashiNums = 1;
        }

        timer.SetStartDayTime();
        player.ResetOneDay();

        if(player.GetMoneyToTheTarget() == 0 && player.StoryLevel < 5)
        {
            player.StoryLevel++;
            var colorFade_ = Instantiate(colorFade);
            colorFade_.transform.SetParent(GameObject.Find("Canvas").transform);
            colorFade_.GetComponent<RectTransform>().localPosition = Vector3.zero;
            colorFade_.GetComponent<RectTransform>().localScale = Vector3.one;
            colorFade_.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Destroy(gameObject);
        }
        else
        {
            GetComponent<SceneChanger>().NextSceneName = "GameMain";
            GetComponent<SceneChanger>().TouchButton();
        }
    }

    private void UpdateEasing()
    {
        if (isEasingEnd)
            return;

        time += Time.deltaTime;
        if (time > easingStart[easingStart.Count - 1] + easingTakeTime[easingTakeTime.Count - 1])
            time = easingStart[easingStart.Count - 1] + easingTakeTime[easingTakeTime.Count - 1];

        totalFoodCost = (int)easing.Linear(
            easing.DelayTime(time, easingStart[0], easingTakeTime[0]),
            0.0f,
            player.OneDayFoodCost);

        totalAnimalPurchaseCost = (int)easing.Linear(
            easing.DelayTime(time, easingStart[1], easingTakeTime[1]),
            0.0f,
            player.OneDayAnimalPurchaseCost);

        totalToyCost = (int)easing.Linear(
            easing.DelayTime(time, easingStart[2], easingTakeTime[2]),
            0.0f,
            player.OneDayToyCost);

        totalVisitors = (int)easing.Linear(
            easing.DelayTime(time, easingStart[3], easingTakeTime[3]),
            0.0f,
            player.OneDayVisitors);

        totalEntranceFee = (int)easing.Linear(
            easing.DelayTime(time, easingStart[4], easingTakeTime[4]),
            0.0f,
            player.entranceFee * player.OneDayVisitors);

        balanceOfPayments = (int)easing.Linear(
            easing.DelayTime(time, easingStart[5], easingTakeTime[5]),
            0.0f,
            totalEntranceFee - (totalFoodCost + totalAnimalPurchaseCost + totalToyCost));
    }

    private void UpdateText()
    {
        if (isEasingEnd)
            return;

        if (time == easingStart[easingStart.Count - 1] + easingTakeTime[easingTakeTime.Count - 1])
            isEasingEnd = true;

        this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = totalFoodCost.ToString();
        this.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = totalAnimalPurchaseCost.ToString();
        this.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = totalToyCost.ToString();
        this.gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = totalVisitors.ToString();
        this.gameObject.transform.GetChild(4).gameObject.GetComponent<Text>().text = totalEntranceFee.ToString();
        this.gameObject.transform.GetChild(5).gameObject.GetComponent<Text>().text = balanceOfPayments.ToString();
    }
}
