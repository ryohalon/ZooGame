using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class CageListManager : MonoBehaviour
{

    public List<GameObject> cageList = new List<GameObject>();

    private GameObject animalList;
    private CombManager combManager = null;
    [SerializeField]
    private GameObject notActiveAnimals = null;

    [SerializeField]
    private int maxCageNum = 9;
    [SerializeField]
    private GameObject cage = null;

    private int changeCageID = -1;

    private Vector2 distance = Vector2.zero;

    public enum TouchType
    {
        NONE,
        TOUCH,
        PRESS,
    }
    public TouchType touchType = TouchType.NONE;

    void Start()
    {
        animalList = GameObject.Find("AnimalList");
        combManager = GameObject.Find("ComboManager").GetComponent<CombManager>();

        distance.x = 65.0f + cage.GetComponent<RectTransform>().rect.width;
        distance.y = 95.0f + cage.GetComponent<RectTransform>().rect.width;

        CreateCage();
        SetCageToAnimal();

        StartCoroutine(UpDateCageList());
    }

    private IEnumerator UpDateCageList()
    {
        while (true)
        {
            EventCage();
            ChangeAnimal();
            GoRaise();

            yield return null;
        }
    }

    private void GoRaise()
    {
        if (touchType != TouchType.PRESS)
            return;

        foreach(var cage_ in cageList)
        {
            
            if (!cage_.GetComponent<PushDownObject>().isPressed)
                continue;


            Debug.Log("Cage : " + cage_.GetComponent<CageManager>().animalID.ToString());
            animalList.GetComponent<SelectAnimalNum>().SelectNum = cage_.GetComponent<CageManager>().animalID;
            break;
        }

        GetComponent<SceneChanger>().NextSceneName = "TestTraining";
        GetComponent<SceneChanger>().TouchButton();
    }

    private void ChangeAnimal()
    {
        if (touchType != TouchType.TOUCH)
            return;

        if (!GameObject.Find(notActiveAnimals.name + "(Clone)").GetComponent<NotActiveAnimals>().is_select)
            return;

        var selectNotActiveAnimalID = GameObject.Find(notActiveAnimals.name + "(Clone)").GetComponent<NotActiveAnimals>().selectID;
        if (selectNotActiveAnimalID != int.MaxValue)
            AnimalSwap(changeCageID, selectNotActiveAnimalID);

        Destroy(GameObject.Find(notActiveAnimals.name + "(Clone)"));
        touchType = TouchType.NONE;

        int[] idList = new int[9];
        for(int i = 0; i < 9; i++)
        {
            idList[i] = cageList[i].GetComponent<CageManager>().animalID;
        }
        
        combManager.CheckCombo(idList);
    }

    private void EventCage()
    {
        if (touchType != TouchType.NONE)
            return;

        for (int i = 0; i < cageList.Count; i++)
        {
            var pushDownPbject = cageList[i].GetComponent<PushDownObject>();
            if (pushDownPbject.isPushed)
            {
                changeCageID = i;
                touchType = TouchType.TOUCH;
                pushDownPbject.isPushed = false;
                var notActiveAnimals_ = Instantiate(notActiveAnimals);
                notActiveAnimals_.transform.SetParent(GameObject.Find("Canvas").transform);
                notActiveAnimals_.GetComponent<RectTransform>().localPosition = Vector3.zero;
                notActiveAnimals_.GetComponent<RectTransform>().localScale = Vector3.one;

            }

            if (pushDownPbject.isPressed)
            {
                touchType = TouchType.PRESS;
            }
        }
    }

    // 檻の生成
    private void CreateCage()
    {
        for (int i = 0; i < maxCageNum; i++)
        {
            cageList.Add(Instantiate(cage));
            cageList[i].transform.SetParent(GameObject.Find("Canvas").transform);
            cageList[i].transform.localPosition =
                new Vector3(
                    distance.x * (i % 3 - 1),
                    distance.y * (i / 3 - 1) - 25.0f,
                    0.0f);
            cageList[i].GetComponent<CageManager>().originPos =
                cageList[i].transform.position;
            cageList[i].transform.localScale = Vector3.one;
        }
    }

    // 檻に動物をセット
    private void SetCageToAnimal()
    {
        var animalList_ = animalList.GetComponent<AnimalStatusCSV>().animals;

        for (int i = 0; i < cageList.Count; i++)
        {
            foreach (var animal in animalList_)
            {
                var animalStatus = animal.GetComponent<AnimalStatusManager>().status;
                if (i != animalStatus.CageID)
                    continue;

                cageList[i].GetComponent<CageManager>().animalID = animalStatus.ID;
                cageList[i].GetComponent<Image>().sprite =
                    animalList.GetComponent<AnimalTextureManager>().animalTextureList[animalStatus.ID][0];
                break;
            }
        }
    }

    // 控えにいる動物との入れ替え
    public void AnimalSwap(int cageID, int animalID)
    {
        var notActiveAnimalID = cageList[cageID].GetComponent<CageManager>().animalID;
        // 檻に入る動物のIDに変更
        cageList[cageID].GetComponent<CageManager>().animalID = animalID;

        var animalList_ = animalList.GetComponent<AnimalStatusCSV>().animals;
        for (int i = 0; i < 13; i++)
        {
            var animalStatus = animalList_[i].GetComponent<AnimalStatusManager>();
            if (animalID == animalStatus.status.ID)
            {
                animalStatus.status.CageID = cageID;
                // アニメーションの変更
                cageList[cageID].GetComponent<Image>().sprite =
                    animalList.GetComponent<AnimalTextureManager>().animalTextureList[i][0];
                continue;
            }

            if (notActiveAnimalID == animalStatus.status.ID)
                animalStatus.status.CageID = -1;
        }
    }
}
