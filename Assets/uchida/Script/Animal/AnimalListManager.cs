using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalListManager : MonoBehaviour
{
    static private AnimalListManager instance = null;

    // すべての動物を読み込む
    void LoadStatus()
    {

    }

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        if(instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }


}
