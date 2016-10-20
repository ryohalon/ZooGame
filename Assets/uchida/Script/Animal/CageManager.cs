using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CageManager : MonoBehaviour
{

    public List<GameObject> cageList = new List<GameObject>();

    [SerializeField]
    private int maxCageNum = 12;
    [SerializeField]
    private GameObject cage = null;

    void Start()
    {
        if (cage == null)
            Debug.Log("eroor : GameObject[cage] が null です");

        for (int i = 0; i < maxCageNum; i++)
        {
            cageList.Add(Instantiate(cage));
            cageList[i].transform.SetParent(GameObject.Find("Canvas").transform);
            cageList[i].transform.localPosition = 
                new Vector3(
                    90.0f * (i % 3 - 1),
                    90.0f * (i / 3 - 2) - 20.0f,
                    cageList[i].transform.position.z);
        }


    }

    public AnimalStatusManager GetAnimal(string name)
    {
        foreach(GameObject cage in cageList)
        {
            var animalStatusManager = cage.GetComponent<AnimalStatusManager>();
            if (!animalStatusManager.IsActive)
                continue;
            if (animalStatusManager.Status.Name != name)
                continue;

            return animalStatusManager;
        }

        Debug.Log("error : [" + name + "] の動物は動物園に存在しません orz");

        return null;
    }

    public void Swap(int i, int k)
    {
        GameObject cage = cageList[i];
        cageList[i] = cageList[k];
        cageList[k] = cage;
    }
}
