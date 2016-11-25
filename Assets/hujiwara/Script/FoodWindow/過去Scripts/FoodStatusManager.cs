using UnityEngine;
using System.Collections;

public class FoodStatusManager : MonoBehaviour
{
    public enum FoodType
    {
        MEET,
        VEGETABLE
    }

    public struct FoodStatus
    {
        // ID
        public int ID { get; set; }
        // 名前
        public string name { get; set; }
        // グレード
        public int grade { get; set; }
        // 値段
        public int purchasePrice { get; set; }
        // 愛情度上昇値
        public int loveDegreeUpValue { get; set; }
        // 満腹度上昇値
        public float satietyLevelUpValue { get; set; }
        // 食べ物の種類
        public FoodType foodType { get; set; }
        // 所持数
        public int possession { get; set; }
    }
    public FoodStatus status_;

    public void Buy()
    {
        status_.possession += 1;
    }

    public void Use()
    {
        status_.possession -= 1;
    }

    // 購入可能か
    public bool CanPurchase(int handMoney)
    {
        if(handMoney > status_.purchasePrice)
        {
            return true;
        }

        return false;
    }

    // 所持数上限か
    public bool IsUpperLimit()
    {
        if (status_.possession > 99)
        {
            return true;
        }

        return false;
    }

    // 所持数下限か
    public bool IsLowerLimit()
    {
        if(0 > status_.possession)
        {
            return true;
        }

        return false;
    }
}
