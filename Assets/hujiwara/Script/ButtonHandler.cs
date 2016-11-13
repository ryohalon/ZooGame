using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public UnityEngine.GameObject window;

    // 各ウィンドウボタンをタッチした時の反応
    public void SetWindowIsActive()
    {
        var isActive = window.activeSelf;

        if(isActive == false)
        {
            window.SetActive(true);
        }
        else
        {
            window.SetActive(false);
        }
    }

    public void TapTab()
    {
        var sibling = window.GetComponent<Transform>();

        sibling.transform.SetAsLastSibling();
    }
}
