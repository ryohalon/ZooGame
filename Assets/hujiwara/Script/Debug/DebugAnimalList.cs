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
        for(int i = 0; i < 10; ++i)
        {
            debugAnimalList.Add(new DebugAnimalStatus());
        }

        for(int i = 0; i < 10; ++i)
        {
            debugAnimalList[i].ID = i;
            debugAnimalList[i].purchasePrice = (i + 1) * 100;
            debugAnimalList[i].isPurchase = false;
        }

        debugAnimalList[0].Name = "シカ";
        debugAnimalList[1].Name = "ヘビ";
        debugAnimalList[2].Name = "クジャク";
        debugAnimalList[3].Name = "サル";
        debugAnimalList[4].Name = "キリン";
        debugAnimalList[5].Name = "クロヒョウ";
        debugAnimalList[6].Name = "パンダ";
        debugAnimalList[7].Name = "タカ";
        debugAnimalList[8].Name = "トラ";
        debugAnimalList[9].Name = "ゾウ";

        Debug.Log("アニマルリスト読み込みました。");
        Debug.Log(debugAnimalList[0].purchasePrice);
    }
}