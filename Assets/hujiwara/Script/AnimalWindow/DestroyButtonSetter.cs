using UnityEngine;
using System.Collections;

public class DestroyButtonSetter : MonoBehaviour
{
    public GameObject BuyWindowYesButton;

    public GameObject destroyButton;

    public void SetDestroyButton()
    {
        var destroyer = BuyWindowYesButton.GetComponent<ButtonDestroyer>();
        destroyer.button = destroyButton;
    }
}
