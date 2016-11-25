using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugFoodList : MonoBehaviour
{
    public GameObject foodStatus;

    public List<FoodStatusManager> foodList = new List<FoodStatusManager>();

    bool isCreate = false;

    void Awake()
    {
        Init();
        if(!isCreate)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Init()
    {
        var food = foodStatus.GetComponent<FoodStatusManager>();

        for(int i = 0; i < 6; ++i)
        {
            foodList.Add(Instantiate(food));
        }

        for(int i = 0; i < 6; ++i)
        {
            foodList[i].status_.ID = i;
            foodList[i].status_.possession = 0;
        }

        for(int i = 0; i < 3; ++i)
        {
            foodList[i].status_.foodType = FoodStatusManager.FoodType.MEET;
        }

        for(int i = 3; i < 6; ++i)
        {
            foodList[i].status_.foodType = FoodStatusManager.FoodType.VEGETABLE;
        }

        foodList[0].status_.grade = 0;
        foodList[1].status_.grade = 1;
        foodList[2].status_.grade = 2;
        foodList[3].status_.grade = 0;
        foodList[4].status_.grade = 1;
        foodList[5].status_.grade = 2;

        foodList[0].status_.purchasePrice = 100;
        foodList[1].status_.purchasePrice = 200;
        foodList[2].status_.purchasePrice = 300;
        foodList[3].status_.purchasePrice = 100;
        foodList[4].status_.purchasePrice = 200;
        foodList[5].status_.purchasePrice = 300;
    }
}
