using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugAnimalList : MonoBehaviour
{
    public List<DebugAnimalStatus> debugAnimalList;

    void Awake()
    {
        debugAnimalList = new List<DebugAnimalStatus>();
    }

    void Start()
    {
        for(int i = 0; i < 4; ++i)
        {
            debugAnimalList.Add(new DebugAnimalStatus());
        }

        for(int i = 0; i < 4; ++i)
        {
            debugAnimalList[i].ID = i;
            debugAnimalList[i].purchasePrice = (i + 1) * 100;
            debugAnimalList[i].isPurchase = false;
        }

        debugAnimalList[0].Name = "シカ";
        debugAnimalList[1].Name = "ヘビ";
        debugAnimalList[2].Name = "クジャク";
        debugAnimalList[3].Name = "サル";

        Debug.Log("アニマルリスト読み込みました。");
        Debug.Log(debugAnimalList[0].purchasePrice);
    }
}