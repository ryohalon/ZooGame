using UnityEngine;
using System.Collections;

public class ItemListroot : MonoBehaviour
{
    [SerializeField]
    GameObject FoodBinder = null;

    [SerializeField]
    GameObject FoodExxplanationText = null;

    [SerializeField]
    GameObject AnimalBinder = null;

    [SerializeField]
    GameObject FoodList = null;

    [SerializeField]
    GameObject AnimalList = null;

    void Start()
    {

    }

    public void PushFood()
    {
        FoodList.SetActive(true);

    }

    public void PushAnimal()
    {
        AnimalList.SetActive(true);

    }

    void Update()
    {

    }
}
