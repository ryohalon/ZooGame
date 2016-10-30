using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalListManager : MonoBehaviour
{
    [SerializeField]
    private GameObject animal = null;

    public List<GameObject> animalList = new List<GameObject>();

    // すべての動物を読み込む
    void LoadStatus()
    {
        
    }

    void Start()
    {
        LoadStatus();
    }

    
}
