using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalListManager : MonoBehaviour
{
    [SerializeField]
    private GameObject animal = null;
    [SerializeField]
    private GameObject animalList_ = null;
    [SerializeField]
    private Sprite debugSprite = null;

    public List<GameObject> animalList = new List<GameObject>();

    // すべての動物を読み込む
    void LoadStatus()
    {

    }

    private void DebugAnimal()
    {
        animal.GetComponent<AnimalStatusManager>().InitStatus();

        for (int i = 0; i < 10; i++)
        {
            animalList.Add(Instantiate(animal));
            animalList[i].transform.SetParent(animalList_.transform);
        }

        for (int i = 0; i < 10; i++)
        {
            animalList[i].GetComponent<AnimalStatusManager>().status.ID = i;
            animalList[i].GetComponent<AnimalStatusManager>().status.IsPurchase = true;
            AnimationManager.AnimationData animationdata = new AnimationManager.AnimationData();
            animationdata.animationTime = 0.0f;
            animationdata.sprite = debugSprite;
            animalList[i].GetComponent<AnimationManager>().animationDataList.Add(animationdata);
            //if (i < 9)
            //    animalList[i].GetComponent<AnimalStatusManager>().status.CageID = i;
            //else
            animalList[i].GetComponent<AnimalStatusManager>().status.CageID = 99;
        }
    }

    void Awake()
    {
        //LoadStatus();
        DebugAnimal();
    }


}
