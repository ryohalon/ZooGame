using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PeopleManager : MonoBehaviour
{
    private AnimalStatusCSV animalStatusCSV = null;
    [SerializeField]
    private GameObject people = null;
    private GameObject canvas = null;
    private FadeIn fadeIn = null;

    public List<GameObject> peopleList = new List<GameObject>();
    public int maxPeopleNums = 0;
    public int ratio = 2;

    private float intervalTime = 0.0f;
    public float maxIntervalTime = 5.0f;

    public float minMoveTakeTime = 2.0f;
    public float maxMoveTakeTime = 5.0f;
    public List<Vector2> movePointList = new List<Vector2>();
    public List<List<Vector2>> moveRootList = new List<List<Vector2>>();
     
    void Start()
    {
        animalStatusCSV = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>();
        canvas = GameObject.Find("Canvas");
        fadeIn = GameObject.Find("FadeIn").GetComponent<FadeIn>();
        intervalTime = maxIntervalTime;

        SetupRoot();
        StartCoroutine(UpdatePeopleManager());
    }

    private void SetupRoot()
    {
        var canvasSize = canvas.GetComponent<RectTransform>().rect.size;
        var referenceResolution = canvas.GetComponent<RectTransform>().rect.size;
        Vector2 differenceRatio;
        differenceRatio.x = referenceResolution.x / canvasSize.x;
        differenceRatio.y = referenceResolution.y / canvasSize.y;

        for (int i = 0; i < movePointList.Count; i++)
        {
            movePointList[i] = new
                Vector2(movePointList[i].x * differenceRatio.x,
                movePointList[i].y * differenceRatio.y);
        }

        List<Vector2> moveRoot = new List<Vector2>();
        moveRoot.Add(movePointList[0]);
        moveRoot.Add(movePointList[3]);
        moveRoot.Add(movePointList[6]);
        moveRoot.Add(movePointList[9]);
        moveRootList.Add(moveRoot);
        moveRoot = new List<Vector2>();

        moveRoot.Add(movePointList[1]);
        moveRoot.Add(movePointList[4]);
        moveRoot.Add(movePointList[7]);
        moveRoot.Add(movePointList[10]);
        moveRootList.Add(moveRoot);
        moveRoot = new List<Vector2>();

        moveRoot.Add(movePointList[2]);
        moveRoot.Add(movePointList[5]);
        moveRoot.Add(movePointList[8]);
        moveRoot.Add(movePointList[11]);
        moveRootList.Add(moveRoot);
        moveRoot = new List<Vector2>();

        moveRoot.Add(movePointList[9]);
        moveRoot.Add(movePointList[6]);
        moveRoot.Add(movePointList[3]);
        moveRoot.Add(movePointList[0]);
        moveRootList.Add(moveRoot);
        moveRoot = new List<Vector2>();

        moveRoot.Add(movePointList[10]);
        moveRoot.Add(movePointList[7]);
        moveRoot.Add(movePointList[4]);
        moveRoot.Add(movePointList[1]);
        moveRootList.Add(moveRoot);
        moveRoot = new List<Vector2>();

        moveRoot.Add(movePointList[11]);
        moveRoot.Add(movePointList[8]);
        moveRoot.Add(movePointList[5]);
        moveRoot.Add(movePointList[2]);
        moveRootList.Add(moveRoot);
        moveRoot = new List<Vector2>();
    }

    private IEnumerator UpdatePeopleManager()
    {
        while (true)
        {
            yield return null;
            if (!fadeIn.isFadeInEnd)
            {
                PeopleDelete();
                continue;
            }

            ChangePeopleNums();

            SpawnPeople();

            UpdatePeople();
        }
    }

    private void ChangePeopleNums()
    {
        intervalTime += Time.deltaTime;
        if (intervalTime < maxIntervalTime)
            return;

        intervalTime = 0.0f;

        float visitors = 0.0f;

        var animals = animalStatusCSV.animals;
        foreach (var animal in animals)
        {
            var animalStatus = animal.GetComponent<AnimalStatusManager>();
            if (animalStatus.status.CageID == -1)
                continue;

            visitors += animalStatus.GetVisitors(1.0f);
        }

        maxPeopleNums = (int)visitors / ratio;
    }

    private void SpawnPeople()
    {
        if (peopleList.Count >= maxPeopleNums)
            return;

        for (int i = 0; i <= (maxPeopleNums - peopleList.Count); i++)
        {
            var people_ = Instantiate(people);
            people_.transform.SetParent(canvas.transform);
            people_.transform.localScale = Vector3.one;
            people_.transform.localPosition = Vector3.zero;
            var peopleMover = people_.GetComponent<PeopleMover>();
            int moveRoot = (int)UnityEngine.Random.Range(0, moveRootList.Count);
            foreach(var movePoint in moveRootList[moveRoot])
            {
                peopleMover.movePointList.Add(movePoint);
                peopleMover.moveTakeTimeList.Add(UnityEngine.Random.Range(minMoveTakeTime, maxMoveTakeTime));
            }

            peopleList.Add(people_);
        }
    }

    private void UpdatePeople()
    {
        for (int i = 0; i < peopleList.Count; i++)
        {
            var peopleMover = peopleList[i].GetComponent<PeopleMover>();
            if (peopleMover.isMoveEnd)
            {
                Destroy(peopleList[i]);
                peopleList.RemoveAt(i);
            }
        }
    }

    public void PeopleDelete()
    {
        for(int i = 0; i < peopleList.Count; i++)
        {
            Destroy(peopleList[i]);
            peopleList.RemoveAt(i);
        }
    }
}
