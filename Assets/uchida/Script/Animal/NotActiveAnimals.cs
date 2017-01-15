using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class NotActiveAnimals : MonoBehaviour
{
    private GameObject animalList = null;
    [SerializeField]
    private GameObject cage = null;

    private List<GameObject> cageList = new List<GameObject>();
    public int selectID = int.MaxValue;
    public bool is_select = false;
    public float distance = 5.0f;

    void Awake()
    {
        is_select = false;
    }

    void Start()
    {
        animalList = GameObject.Find("AnimalList");

        distance = 10.0f + cage.GetComponent<RectTransform>().rect.width;
        CreateCage();

        StartCoroutine(UpdateNotActiveAnimals());
    }

    private void CreateCage()
    {
        var animalList_ = animalList.GetComponent<AnimalStatusCSV>().animals;
        for(int i = 0; i < 13; i++)
        {
            var animalStatus = animalList_[i].GetComponent<AnimalStatusManager>();
            if (animalStatus.status.IsPurchase == false)
                continue;
            if (animalStatus.status.CageID != -1)
                continue;

            cageList.Add(Instantiate(cage));
            cageList[cageList.Count - 1].transform.SetParent(GameObject.Find("Canvas").transform);
            cageList[cageList.Count - 1].GetComponent<CageManager>().animalID = animalStatus.status.ID;
            cageList[cageList.Count - 1].transform.localScale = Vector3.one;
            cageList[cageList.Count - 1].GetComponent<PushDownObject>().pushOnly = true;
            cageList[cageList.Count - 1].GetComponent<DragObject>().isDrag = false;
            cageList[cageList.Count - 1].GetComponent<DropObject>().isDrop = false;
            cageList[cageList.Count - 1].GetComponent<Image>().sprite =
                animalList.GetComponent<AnimalTextureManager>().animalTextureList[i][0];
        }

        for (int i = 0; i < cageList.Count; i++)
        {
            cageList[i].transform.localPosition =
                new Vector3(distance * (i % 3 - 1),
                distance * (-i / 3 + 1) + 25.0f,
                22.0f);
            cageList[i].GetComponent<AnimalMover>().isNotMove = true;
        }
    }

    private IEnumerator UpdateNotActiveAnimals()
    {
        while (true)
        {
            SelectAnimal();

            yield return null;
        }
    }

    private void SelectAnimal()
    {
        if (is_select)
            return;

        foreach (var cage in cageList)
        {
            var pushDownObject = cage.GetComponent<PushDownObject>();
            if (pushDownObject.isPushed)
            {
                selectID = cage.GetComponent<CageManager>().animalID;
                is_select = true;
                break;
            }
        }

        var backPushDownOject = transform.GetChild(0).gameObject.GetComponent<PushDownObject>();
        if (backPushDownOject.isPushed)
        {
            SoundManager.Instance.PlaySE((int)SEList.CLOSE);
            is_select = true;
        }

        if (is_select)
        {
            foreach (var cage in cageList)
                Destroy(cage);
        }
    }
}
