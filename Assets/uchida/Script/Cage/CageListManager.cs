using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class CageListManager : MonoBehaviour
{

    //public List<GameObject> cageList = new List<GameObject>();

    //[SerializeField]
    //private GameObject animalListManager = null;

    //[SerializeField]
    //private int maxCageNum = 9;
    //[SerializeField]
    //private GameObject cage = null;

    //private int changeCageID = 99;

    //private float distance = 0.0f;

    //[SerializeField]
    //private float maxPressTime = 2.0f;
    //private float pressTime = 0.0f;
    //public enum TouchType
    //{
    //    NONE,
    //    TOUCH,
    //    PRESS,
    //    SWIPE,
    //}
    //public TouchType touchType = TouchType.NONE;
    //private bool prevMouseDown = false;

    //void Start()
    //{
    //    if (cage == null)
    //        Debug.Log("eroor : GameObject[cage] が null です");

    //    distance = 15.0f + cage.GetComponent<RectTransform>().rect.width;

    //    CreateCage();
    //    SetCageToAnimal();

    //    StartCoroutine(UpDateCageList());
    //}

    //private IEnumerator UpDateCageList()
    //{
    //    while (true)
    //    {
    //        EventCage();
    //        CageSwap();
    //        ChangeAnimal();
    //        GoRaise();

    //        //if (Input.GetMouseButtonDown(0))
    //        //{
    //        //    Debug.Log("mousepos : " + Input.mousePosition);
    //        //    Debug.Log("cageList[0] : " + cageList[0].transform.localPosition);
    //        //}

    //        yield return null;
    //    }
    //}

    //private void GoRaise()
    //{
    //    if (touchType != TouchType.PRESS)
    //        return;
    //    GetComponent<SceneChanger>().TouchButton();
    //}

    //private void ChangeAnimal()
    //{
    //    if (touchType != TouchType.TOUCH)
    //        return;

    //    touchType = TouchType.NONE;
    //}

    //private void CageSwap()
    //{
    //    if (touchType != TouchType.SWIPE)
    //        return;

    //    // スワイプ中の檻をタッチしているところに追従させる
    //    Vector3 mousePos = Input.mousePosition;
    //    cageList[changeCageID].transform.position =
    //        new Vector3(mousePos.x,
    //        mousePos.y,
    //        cageList[changeCageID].transform.position.z);

    //    // 離さない限り何もしない
    //    if (!Input.GetMouseButtonUp(0))
    //        return;

    //    // スワイプしていた檻を元の位置に戻す
    //    cageList[changeCageID].transform.position = cageList[changeCageID].GetComponent<CageManager>().originPos;

    //    for (int i = 0; i < cageList.Count; i++)
    //    {
    //        // スワイプしていた檻と同じものだったらはじく
    //        if (i == changeCageID)
    //            continue;

    //        if (!cageList[i].GetComponent<CageManager>().IsHit())
    //            continue;

    //        CageSwap(changeCageID, i);
    //        Debug.Log("すわっぴー");
    //        break;
    //    }

    //    touchType = TouchType.NONE;
    //}

    //private void EventCage()
    //{
    //    if (touchType != TouchType.NONE)
    //        return;

    //    for (int i = 0; i < cageList.Count; i++)
    //    {
    //        if (cageList[i].GetComponent<CageManager>().IsHit())
    //        {
    //            //Debug.Log("HIT : " + i);

    //            if (Input.GetMouseButtonDown(0))
    //            {
    //                changeCageID = i;
    //                pressTime = 0.0f;
    //                prevMouseDown = false;
    //            }

    //            if (Input.GetMouseButton(0))
    //            {
    //                if (pressTime < maxPressTime)
    //                {
    //                    pressTime = Mathf.Min(maxPressTime, pressTime + Time.deltaTime);

    //                    if (prevMouseDown == false && pressTime < maxPressTime / 2.0f)
    //                    {
    //                        prevMouseDown = true;
    //                    }

    //                    break;
    //                }
    //                else
    //                {
    //                    touchType = TouchType.PRESS;
    //                    pressTime = 0.0f;
    //                    prevMouseDown = false;
    //                    Debug.Log("touchType : " + touchType);
    //                    Debug.Log("changeCageID : " + changeCageID);
    //                    break;
    //                }
    //            }

    //            if (Input.GetMouseButtonUp(0))
    //            {
    //                touchType = TouchType.TOUCH;
    //                pressTime = 0.0f;
    //                prevMouseDown = false;
    //                Debug.Log("touchType : " + touchType);
    //                Debug.Log("changeCageID : " + changeCageID);
    //            }
    //        }
    //        else if (prevMouseDown == true && Input.GetMouseButton(0))
    //        {
    //            touchType = TouchType.SWIPE;
    //            pressTime = 0.0f;
    //            prevMouseDown = false;
    //            Debug.Log("touchType : " + touchType);
    //            Debug.Log("changeCageID : " + changeCageID);
    //            break;
    //        }
    //    }

    //    if (pressTime >= maxPressTime / 2.0f && prevMouseDown == true)
    //        prevMouseDown = false;
    //}

    //// 檻の生成
    //private void CreateCage()
    //{
    //    for (int i = 0; i < maxCageNum; i++)
    //    {
    //        cageList.Add(Instantiate(cage));
    //        cageList[i].transform.SetParent(GameObject.Find("Canvas").transform);
    //        cageList[i].transform.localPosition =
    //            new Vector3(
    //                distance * (i % 3 - 1),
    //                distance * (i / 3 - 1) - 20.0f,
    //                cageList[i].transform.localPosition.z);
    //        cageList[i].GetComponent<CageManager>().originPos = cageList[i].transform.position;


    //        cageList[i].transform.FindChild("Text").GetComponent<Text>().text = i.ToString();
    //    }
    //}

    //// 檻に動物をセット
    //private void SetCageToAnimal()
    //{
    //    var animalList = animalListManager.GetComponent<AnimalListManager>().animalList;

    //    for (int i = 0; i < cageList.Count; i++)
    //    {
    //        foreach (var animal in animalList)
    //        {
    //            var animalStatus = animal.GetComponent<AnimalStatusManager>().status;
    //            if (i != animalStatus.CageID)
    //                continue;

    //            cageList[i].GetComponent<CageManager>().animalID = animalStatus.ID;
    //            cageList[i].GetComponent<AnimationManager>().animationDataList = animal.GetComponent<AnimationManager>().animationDataList;
    //            break;
    //        }
    //    }
    //}

    //// 檻に入っている動物の配置入れ替え
    //public void CageSwap(int i, int k)
    //{
    //    GameObject cage = cageList[i];
    //    cageList[i] = cageList[k];
    //    cageList[k] = cage;

    //    // Debug
    //    cageList[i].transform.FindChild("Text").GetComponent<Text>().text = k.ToString();
    //    cageList[k].transform.FindChild("Text").GetComponent<Text>().text = i.ToString();
    //}

    //// 控えにいる動物との入れ替え
    //public void AnimalSwap(int cageID, int animalID)
    //{
    //    var animalList = animalListManager.GetComponent<AnimalListManager>().animalList;

    //    for (int i = 0; i < animalList.Count; i++)
    //    {
    //        var animalStatus = animalList[i].GetComponent<AnimalStatusManager>();
    //        if (animalID == animalStatus.status.ID)
    //        {
    //            // 檻に入る動物
    //            animalStatus.IsActive = true;
    //            animalStatus.status.CageID = cageID;
    //            // アニメーションの変更
    //            cageList[cageID].GetComponent<AnimationManager>().animationDataList =
    //                animalList[i].GetComponent<AnimationManager>().animationDataList;

    //            continue;
    //        }
    //        if (cageList[cageID].GetComponent<CageManager>().animalID == animalStatus.status.ID)
    //        {
    //            // 控えに移動する動物
    //            animalStatus.IsActive = false;
    //            animalStatus.status.CageID = 99;
    //        }
    //    }

    //    // 檻に入る動物のIDに変更
    //    cageList[cageID].GetComponent<CageManager>().animalID = animalID;
    //}
}
