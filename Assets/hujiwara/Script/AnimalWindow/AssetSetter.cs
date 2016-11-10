using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AssetSetter : MonoBehaviour
{
    public FoodStatusAsset _asset;

    public GameObject _text;

    public void SetAsset()
    {
        var test = _text.GetComponent<TextChanger>();
        test._food = _asset;

        test.UpdateFoodStatusAsset();
    }
}