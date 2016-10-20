using UnityEngine;
using System.Collections;

public class AnimalStatusManager : MonoBehaviour
{
    public enum Sexuality
    {
        MALE,
        FEMALE,
    }

    public struct AnimalStatus
    {
        // ID
        public int ID { get; set; }
        // 名前
        public string Name { get; set; }
        // 購入金額
        public int PurchasePrice { get; set; }
        // 一日にかかる食費
        public int FoodCost { get; set; }
        // 満腹度
        public int SatietyLevel { get; set; }
        // 愛情度
        public int LoveDegree { get; set; }
        // 次のレベルまでの値
        public int NextLevel { get; set; }
        // 呼び込める客の数
        public int AttractVisitors { get; set; }
        // 倍率
        public float Ratio { get; set; }
        // 性別
        public Sexuality Sexuality { get; set; }
        // レア度
        public int Rarity { get; set; }
    }
    public AnimalStatus Status { get; set; }

    public bool IsActive { get; set; }


    // 経過した時間分の来場客数の計算
    //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
    // プランナーに用相談
    //＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
    public int GetVisitors(float elapsedTime)
    {
        float visitors = (float)Status.AttractVisitors * Status.Ratio* elapsedTime;

        return (int)visitors;
    }


    // 動物の配置入れ替え
    // 返り値で帰ってくるので、ステータスを渡した側は返り値で変更する
    // 使わない可能性(大)
    public AnimalStatus Swap(AnimalStatus status1)
    {
        var status2 = this.GetComponent<AnimalStatusManager>().Status;
        AnimalStatus status3 = status2;
        status2 = status1;

        return status3;
    }
}