using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PeopleManager : MonoBehaviour
{
    private AnimalStatusCSV animalStatusCSV = null;
    [SerializeField]
    private GameObject people = null;

    private List<GameObject> peopleList = new List<GameObject>();
    private int maxPeopleNums = 0;

    private float intervalTime = 0.0f;
    private float maxIntervalTime = 5.0f;

    private float[] peopleSpawnPoint = new float[]
    {
        0.0f, 0.0f,
        0.0f, 0.0f,
        0.0f, 0.0f
    };

    void Start()
    {
        animalStatusCSV = GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>();

        StartCoroutine(UpdatePeopleManager());
    }

    private IEnumerator UpdatePeopleManager()
    {
        while(true)
        {
            ChangePeopleNums();

            SpawnPeople();

            UpdatePeople();

            yield return null;
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
        foreach(var animal in animals)
        {
            var animalStatus = animal.GetComponent<AnimalStatusManager>();
            if (animalStatus.status.CageID == -1)
                continue;

            visitors += animalStatus.GetVisitors(1.0f);
        }

        maxPeopleNums = (int)visitors;
    }

    private void SpawnPeople()
    {
        if (peopleList.Count >= maxPeopleNums)
            return;

        for(int i = 0; i <= (maxPeopleNums - peopleList.Count); i++)
        {
            
        }
    }

    private void UpdatePeople()
    {
        for(int i = 0; i < peopleList.Count; i++)
        {
            var people = peopleList[i].GetComponent<PeopleMover>();
            if (people.isMoveEnd)
                Destroy(peopleList[i]);
        }
    }
}
