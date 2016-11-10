using UnityEngine;
using UnityEngine.UI;

public class PriceChanger : MonoBehaviour
{
    public FoodStatusAsset _asset;

    public GameObject _gameObject;

    void Start()
    {
        gameObject.GetComponent<Text>().text = _asset._foodStatus.Price.ToString();
    }
}
