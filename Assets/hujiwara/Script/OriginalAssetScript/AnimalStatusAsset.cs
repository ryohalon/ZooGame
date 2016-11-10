using UnityEngine;
using System.Collections;

public class AnimalStatusAsset : ScriptableObject
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("CustomAssets/Create/AnimalStatus")]
    static void CreateAsset()
    {
        var asset = CreateInstance<AnimalStatusAsset>();
        UnityEditor.ProjectWindowUtil.CreateAsset(asset, "animal.asset");
    }

#endif
}
