using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    Text _price;

    public GameObject animalList;

    void Start()
    {
        _price = gameObject.GetComponent<Text>();
        UpdateFoodStatusAsset();
    }

    public void UpdateFoodStatusAsset()
    {
        
    }
}
