using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PossessionSetter : MonoBehaviour
{
    public GameObject foodList;
    public int ID;

    private DebugFoodList food;

    void Start()
    {
        food = foodList.GetComponent<DebugFoodList>();
    }

    void Update()
    {
        gameObject.GetComponent<Text>().text = food.foodList[ID].status_.possession.ToString();
    }
}
