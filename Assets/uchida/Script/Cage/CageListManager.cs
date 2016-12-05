using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class CageListManager : MonoBehaviour
{

    public List<GameObject> cageList = new List<GameObject>();

    [SerializeField]
    private GameObject animalListManager = null;
    [SerializeField]
    private GameObject notActiveAnimals = null;

    [SerializeField]
    private int maxCageNum = 9;
    [SerializeField]
    private GameObject cage = null;

    private int changeCageID = 99;

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
        if (cage == null)
            Debug.Log("eroor : GameObject[cage] が null です");

        distance.x = 30.0f + cage.GetComponent<RectTransform>().rect.width;
        distance.y = 45.0f + cage.GetComponent<RectTransform>().rect.width;

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

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawLine(ray.origin, ray.direction * 50);

            yield return null;
        }
    }

    private void GoRaise()
    {
        if (touchType != TouchType.PRESS)
            return;
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
        {
            AnimalSwap(changeCageID, selectNotActiveAnimalID);
        }

        Destroy(GameObject.Find(notActiveAnimals.name + "(Clone)"));
        touchType = TouchType.NONE;

        foreach (var cage in cageList)
            Debug.Log(cage.GetComponent<CageManager>().animalID);
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
                pushDownPbject.isPressed = false;
                animalListManager.GetComponent<AnimalListManager>().animalList[i].GetComponent<AnimalStatusManager>().IsRaise = true;
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
                    distance.y * (i / 3 - 1) - 15.0f,
                    0.0f);
            cageList[i].GetComponent<CageManager>().originPos =
                cageList[i].transform.position;
            cageList[i].transform.localScale = Vector3.one;

            cageList[i].transform.FindChild("Text").GetComponent<Text>().text = i.ToString();
        }
    }

    // 檻に動物をセット
    private void SetCageToAnimal()
    {
        var animalList = animalListManager.GetComponent<AnimalListManager>().animalList;

        for (int i = 0; i < cageList.Count; i++)
        {
            foreach (var animal in animalList)
            {
                var animalStatus = animal.GetComponent<AnimalStatusManager>().status;
                if (i != animalStatus.CageID)
                    continue;

                cageList[i].GetComponent<CageManager>().animalID = animalStatus.ID;
                //cageList[i].GetComponent<AnimationManager>().animationDataList =
                //    animal.GetComponent<AnimationManager>().animationDataList;
                break;
            }
        }
    }

    // 檻に入っている動物の配置入れ替え
    public void CageSwap(int i, int k)
    {
        GameObject cage = cageList[i];
        cageList[i] = cageList[k];
        cageList[k] = cage;

        // Debug
        cageList[i].transform.FindChild("Text").GetComponent<Text>().text = k.ToString();
        cageList[k].transform.FindChild("Text").GetComponent<Text>().text = i.ToString();
    }

    // 控えにいる動物との入れ替え
    public void AnimalSwap(int cageID, int animalID)
    {
        var notActiveAnimalID = cageList[cageID].GetComponent<CageManager>().animalID;
        // 檻に入る動物のIDに変更
        cageList[cageID].GetComponent<CageManager>().animalID = animalID;

        var animalList = animalListManager.GetComponent<AnimalListManager>().animalList;
        for (int i = 0; i < animalList.Count; i++)
        {
            var animalStatus = animalList[i].GetComponent<AnimalStatusManager>();
            if (animalID == animalStatus.status.ID)
            {
                animalStatus.status.CageID = cageID;
                // アニメーションの変更
                cageList[cageID].GetComponent<AnimationManager>().animationDataList =
                    animalList[i].GetComponent<AnimationManager>().animationDataList;
                // debug
                if (animalList[i].GetComponent<AnimationManager>().animationDataList.Count > 0)
                {
                    cageList[cageID].GetComponent<Image>().sprite =
                        animalList[i].GetComponent<AnimationManager>().animationDataList[0].sprite;
                }

                continue;
            }

            if (notActiveAnimalID == animalStatus.status.ID)
                animalStatus.status.CageID = 99;
        }
    }
}
