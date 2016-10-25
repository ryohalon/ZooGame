using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalManager : MonoBehaviour
{

    [SerializeField]
    private GameObject cageManager = null;

    public List<GameObject> animalList = new List<GameObject>();

    void LoadStatus()
    {
        Debug.Log("何も書いてない");
    }

    void Start()
    {
        if (cageManager == null)
            Debug.Log("cageManager is empty!");
    }

    
}
