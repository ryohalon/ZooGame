using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Cage2ListManager : MonoBehaviour
{
    public List<GameObject> cageList = new List<GameObject>();

    [SerializeField]
    private GameObject animalListManager = null;
    [SerializeField]
    private GameObject NotActiveAnimals = null;

    [SerializeField]
    private int maxCageNum = 9;
    [SerializeField]
    private GameObject cage2 = null;

    private int changeCageID = 99;

    private float distance = 0.0f;

    [SerializeField]
    private float maxPressTime = 2.0f;
    private float pressTime = 0.0f;
    public enum TouchType
    {
        NONE,
        TOUCH,
        PRESS,
        SWIPE,
    }
    public TouchType touchType = TouchType.NONE;
    private bool prevMouseDown = false;
    private bool is_push = false;

    void Start()
    {
        if (cage2 == null)
            Debug.Log("eroor : GameObject[cage] が null です");

        distance = 5.0f;

        CreateCage();
        SetCageToAnimal();

        StartCoroutine(UpDateCageList());
    }

    private IEnumerator UpDateCageList()
    {
        while (true)
        {
            EventCage();
            CageSwap();
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
        GetComponent<SceneChanger>().TouchButton();
    }

    private void ChangeAnimal()
    {
        if (touchType != TouchType.TOUCH)
            return;

        if (!GameObject.Find(NotActiveAnimals.name + "(Clone)").GetComponent<NotActiveAnimals>().is_select)
            return;

        var selectNotActiveAnimalID = GameObject.Find(NotActiveAnimals.name + "(Clone)").GetComponent<NotActiveAnimals>().selectID;
        if (selectNotActiveAnimalID != int.MaxValue)
        {
            AnimalSwap(changeCageID, selectNotActiveAnimalID);
        }

        Destroy(GameObject.Find(NotActiveAnimals.name + "(Clone)"));
        touchType = TouchType.NONE;
        is_push = false;

        foreach (var cage in cageList)
            Debug.Log(cage.GetComponent<CageManager>().animalID);
    }

    private void CageSwap()
    {
        if (touchType != TouchType.SWIPE)
            return;

        // スワイプ中の檻をタッチしているところに追従させる
        Vector3 pos = GetComponent<RayCollision>().HitRayPosCameraToMouse();
        cageList[changeCageID].transform.position =
            new Vector3(pos.x,
            pos.y,
            cageList[changeCageID].transform.position.z);

        // 離さない限り何もしない
        if (!Input.GetMouseButtonUp(0))
            return;

        // スワイプしていた檻を元の位置に戻す
        cageList[changeCageID].transform.position = cageList[changeCageID].GetComponent<CageManager>().originPos;

        for (int i = 0; i < cageList.Count; i++)
        {
            // スワイプしていた檻と同じものだったらはじく
            if (i == changeCageID)
                continue;

            if (!cageList[i].GetComponent<Collision>().IsHit(GetComponent<RayCollision>().HitRayPosCameraToMouse()))
                continue;

            CageSwap(changeCageID, i);
            Debug.Log("すわっぴー");
            break;
        }

        touchType = TouchType.NONE;
        is_push = false;
    }

    private void EventCage()
    {
        if (touchType != TouchType.NONE)
            return;

        for (int i = 0; i < cageList.Count; i++)
        {
            if (cageList[i].GetComponent<Collision>().IsHit(GetComponent<RayCollision>().HitRayPosCameraToMouse()))
            {
                if (!is_push)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        is_push = true;
                        prevMouseDown = true;
                        changeCageID = i;
                    }

                    break;
                }

                if (Input.GetMouseButton(0))
                {
                    if (pressTime < maxPressTime)
                    {
                        pressTime = Mathf.Min(maxPressTime, pressTime + Time.deltaTime);

                        if (prevMouseDown == true && pressTime >= maxPressTime / 2.0f)
                            prevMouseDown = false;

                        break;
                    }

                    if (pressTime == maxPressTime)
                    {
                        if (animalListManager.GetComponent<AnimalListManager>().animalList.Count > 0)
                            animalListManager.GetComponent<AnimalListManager>().animalList[changeCageID].GetComponent<AnimalStatusManager>().IsRaise = true;
                        touchType = TouchType.PRESS;
                        pressTime = 0.0f;
                        prevMouseDown = false;
                        Debug.Log("touchType : " + touchType);
                        Debug.Log("changeCageID : " + changeCageID);
                        break;
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    touchType = TouchType.TOUCH;
                    pressTime = 0.0f;
                    prevMouseDown = false;
                    Debug.Log("touchType : " + touchType);
                    Debug.Log("changeCageID : " + changeCageID);

                    Instantiate(NotActiveAnimals);

                    break;
                }

                break;
            }
            else if (prevMouseDown == true && is_push && changeCageID == i)
            {
                touchType = TouchType.SWIPE;
                pressTime = 0.0f;
                prevMouseDown = false;
                cageList[changeCageID].transform.position =
                    cageList[changeCageID].transform.position + new Vector3(0.0f, 0.0f, -1.0f);
                Debug.Log("touchType : " + touchType);
                Debug.Log("changeCageID : " + changeCageID);
                break;
            }
        }
    }

    // 檻の生成
    private void CreateCage()
    {
        for (int i = 0; i < maxCageNum; i++)
        {
            cageList.Add(Instantiate(cage2));
            cageList[i].transform.position =
            new Vector3(
                distance * (i % 3 - 1),
                distance * (i / 3 - 1),
                25.0f);
            cageList[i].GetComponent<CageManager>().originPos = cageList[i].transform.position;
            cageList[i].transform.SetParent(GameObject.Find("CageList").transform);
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
                //cageList[i].GetComponent<SpriteAnimationManager>().animationDataList =
                //    animal.GetComponent<SpriteAnimationManager>().animationDataList;
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
                cageList[cageID].GetComponent<SpriteAnimationManager>().animationDataList =
                    animalList[i].GetComponent<SpriteAnimationManager>().animationDataList;
                // debug
                cageList[cageID].GetComponent<SpriteRenderer>().sprite = animalList[i].GetComponent<SpriteAnimationManager>().animationDataList[0].sprite;

                continue;
            }

            if (notActiveAnimalID == animalStatus.status.ID)
                animalStatus.status.CageID = 99;
        }
    }
}
