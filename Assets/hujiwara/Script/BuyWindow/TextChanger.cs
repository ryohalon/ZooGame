using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    Text _price;

    public FoodStatusAsset _food;

    void Start()
    {
        _price = gameObject.GetComponent<Text>();
        UpdateFoodStatusAsset();
    }

    public void UpdateFoodStatusAsset()
    {
        if (_food != null && _price)
        {
            _price.text = _food._foodStatus.Price.ToString();
        }
    }
}
