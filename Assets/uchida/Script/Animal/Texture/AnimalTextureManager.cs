using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class AnimalTextureManager : MonoBehaviour
{
    public List<List<Sprite>> animalTextureList = new List<List<Sprite>>();

    [SerializeField]
    private List<Sprite> animalTextures = new List<Sprite>();

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < animalTextures.Count; i += 2)
        {
            List<Sprite> animalTextureList_ = new List<Sprite>();
            for (int k = 0; k < 2; k++)
            {
                animalTextureList_.Add(animalTextures[i + k]);
            }

            animalTextureList.Add(animalTextureList_);
        }
    }
}
