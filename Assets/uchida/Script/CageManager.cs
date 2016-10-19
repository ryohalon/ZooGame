using UnityEngine;
using System.Collections;

public class CageManager : MonoBehaviour
{
    enum Sexuality
    {
        MALE,
        FEMALE,
    }

    struct AnimalStatus
    {
        // ID
        int id;
        // 名前
        string name;
        // 購入金額
        int purchasePrice;
        // 一日にかかる食費
        int foodCost;
        // 愛情度
        int loveDegree;
        // 次のレベルまでの値
        int nextLevel;
        // 呼び込める客の数
        int attractNum;
        // 性別
        Sexuality sexuality;
        // レア度
        int rarity;
    }
    private AnimalStatus Status { get; set; }

    bool IsActive { get; set; }

    void Start()
    {
        StartCoroutine(UpdateCage());
    }

    IEnumerator UpdateCage()
    {
        while(true)
        {


            yield return null;
        }
    }
}
