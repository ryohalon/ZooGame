using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonDestroyer : MonoBehaviour
{
    public GameObject button;

    public void Destroy()
    {
        button.SetActive(false);
    }
}
