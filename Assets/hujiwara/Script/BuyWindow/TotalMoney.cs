using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TotalMoney : MonoBehaviour
{
    public Text _totalMoney;

    public Text _price;

    void Start()
    {
        _totalMoney = gameObject.GetComponent<Text>();
    }


}