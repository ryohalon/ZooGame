using UnityEngine;
using System.Collections;

public class FoodStatusAsset : ScriptableObject
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("CustomAssets/Create/FoodStatus")]
    static void CreateAsset()
    {
        var asset = CreateInstance<FoodStatusAsset>();
        UnityEditor.ProjectWindowUtil.CreateAsset(asset, "food.asset");
    }
#endif

    public FoodStatus _foodStatus = null;

}
