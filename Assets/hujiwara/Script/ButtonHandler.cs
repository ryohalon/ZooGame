using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject window;

    public void TouchButton()
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
