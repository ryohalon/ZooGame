using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menu = null;

    public void CreateMenu()
    {
        if (GameObject.Find("Menu(Clone)") == null)
            Instantiate(menu);
    }
    public void DestroyMenu() { Destroy(GameObject.Find("Menu(Clone)")); }
}
