using UnityEngine;
using System.Collections;

public class FoodStatusManager : MonoBehaviour
{
    public struct FoodStatus
    {
        // 名前
        string Name { get; set; }
        // グレード(1低い ← 2普通 →3高級)
        int Grade { get; set; }
        // 購入金額
        int PurchasePrice { get; set; }
        // 愛情度上昇値
        int LoveDegreeUpValue { get; set; }
        // 満腹度上昇値
        int FullStomachDegreeUpValue { get; set; }
        // 個数
        int number { get; set; }
    }

    public FoodStatus foodStatus { get; set; }
}
