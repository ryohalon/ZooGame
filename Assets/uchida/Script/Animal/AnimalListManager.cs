using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalListManager : MonoBehaviour
{
    [SerializeField]
    private GameObject animal = null;
    [SerializeField]
    private Sprite debugSprite = null;

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
            AnimationManager.AnimationData animationdata = new AnimationManager.AnimationData();
            animationdata.animationTime = 0.0f;
            animationdata.sprite = debugSprite;
            animalList[i].GetComponent<AnimationManager>().animationDataList.Add(animationdata);
            animalList[i].GetComponent<AnimalStatusManager>().status.CageID = 99;
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
