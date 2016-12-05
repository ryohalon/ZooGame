using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PurchaseCountChanger : MonoBehaviour
{
    public int counter;

    void Start()
    {
        counter = 1;
        TextUpdater();
    }

    public void TextUpdater()
    {
        var count = gameObject.GetComponent<Text>();
        count.text = counter.ToString();
        Debug.Log("counter=" + counter);
    }

    public int GetCounter()
    {
        return counter;
    }
}
