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
            debugAnimalList[i].isPurchase = false;
        }

        debugAnimalList[0].Name = "シカ";
        debugAnimalList[1].Name = "ヘビ";

        debugAnimalList[2].Name = "クジャク";
        debugAnimalList[2].purchasePrice = 50000;

        debugAnimalList[3].Name = "サル";
        debugAnimalList[3].purchasePrice = 80000;

        debugAnimalList[4].Name = "キリン";
        debugAnimalList[4].purchasePrice = 200000;

        debugAnimalList[5].Name = "クロヒョウ";
        debugAnimalList[5].purchasePrice = 200000;

        debugAnimalList[6].Name = "パンダ";
        debugAnimalList[6].purchasePrice = 200000;

        debugAnimalList[7].Name = "タカ";
        debugAnimalList[7].purchasePrice = 150000;

        debugAnimalList[8].Name = "トラ";
        debugAnimalList[8].purchasePrice = 200000;

        debugAnimalList[9].Name = "ゾウ";
        debugAnimalList[9].purchasePrice = 150000;


        Debug.Log("アニマルリスト読み込みました。");
        Debug.Log(debugAnimalList[0].purchasePrice);
    }
}