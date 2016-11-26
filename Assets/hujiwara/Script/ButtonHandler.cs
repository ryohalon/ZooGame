using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject window = null;
    public GameObject thisLayer = null;

    // 各ウィンドウボタンをタッチした時の反応
    public void SetWindowIsActive()
    {
        var windowIsActive = window.activeSelf;
        var thisLayerIsActive = thisLayer.activeSelf;

        if(windowIsActive == false)
        {
            window.SetActive(true);
        }
        else
        {
            window.SetActive(false);
        }

        if(thisLayerIsActive == false)
        {
            thisLayer.SetActive(true);
        }
        else
        {
            thisLayer.SetActive(false);
        }
    }
}
