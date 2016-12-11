using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalListManager : MonoBehaviour
{
    [SerializeField]
    private GameObject animal = null;
    public List<GameObject> animalList = new List<GameObject>();

    static private AnimalListManager instance = null;

    // すべての動物を読み込む
    void LoadStatus()
    {

    }

    public void DebugAnimal()
    {
        animal.GetComponent<AnimalStatusManager>().InitStatus();

        for (int i = 0; i < 10; i++)
        {
            var animal_ = Instantiate(animal);
            animal_.transform.SetParent(transform);
            animalList.Add(animal_);
        }

        for (int i = 0; i < 10; i++)
        {
            animalList[i].GetComponent<AnimalStatusManager>().status.ID = i;
            animalList[i].GetComponent<AnimalStatusManager>().status.IsPurchase = true;
            animalList[i].GetComponent<AnimalStatusManager>().status.AttractVisitors = 20;
            animalList[i].GetComponent<AnimalStatusManager>().status.SatietyLevel = 100;
            animalList[i].GetComponent<AnimalStatusManager>().status.Ratio = 1.0f;
            animalList[i].GetComponent<AnimalStatusManager>().status.CageID = -1;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;

            //LoadStatus();
            DebugAnimal();
        }
        if(instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }


}
