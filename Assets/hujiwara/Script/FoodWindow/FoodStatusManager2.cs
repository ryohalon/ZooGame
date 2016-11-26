using UnityEngine;
using System.Collections;

public class FoodStatusManager2 : MonoBehaviour
{
    // ID
    public int ID { get; set; }
    // 名前
    public string Name { get; set; }
    // 値段
    public int purchasePrice { get; set; }
    // 愛情度上昇値
    public float loveDegreeUpValue { get; set; }
    // 満腹度上昇値
    public float satietyLevelUpValue { get; set; }
    // 食べ物の種類(0=肉, 1=野菜)
    public int foodType { get; set; }
    // 所持数
    public int possessionNumber { get; set; }

    // コンストラクタ
    public FoodStatusManager2() { }

    public FoodStatusManager2(
        int ID, string Name, int purchasePrice, 
        float loveDegreeUpValue,float satietyLevelUpValue,
        int foodType, int possessionNumber)
    {
        this.ID = ID;
        this.Name = Name;
        this.purchasePrice = purchasePrice;
        this.loveDegreeUpValue = loveDegreeUpValue;
        this.satietyLevelUpValue = satietyLevelUpValue;
        this.foodType = foodType;
        this.possessionNumber = possessionNumber;
    }
}