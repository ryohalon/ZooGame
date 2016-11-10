using UnityEngine;

[System.Serializable]
public class FoodStatus
{
    [SerializeField]
    string _name = string.Empty;

    public string Name { get { return _name; } }

    [SerializeField]
    int _grade = 1;

    public int Grade { get { return _grade; } }

    [SerializeField]
    int _price = 100;

    public int Price { get { return _price; } }

    [SerializeField]
    int _loveDegreeUpValue = 0;

    public int LoveDegreeUpValue { get { return _loveDegreeUpValue; } }

    [SerializeField]
    int _satietyLevelUpValue = 1;

    public int SatietyLevelUpValue { get { return _satietyLevelUpValue; } }

    [SerializeField]
    int _possessionNumber = 0;

    public int PossessionNumber { get { return _possessionNumber; } }
}
