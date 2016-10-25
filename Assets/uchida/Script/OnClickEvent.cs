using UnityEngine;
using System.Collections;

public class OnClickEvent : MonoBehaviour
{
    public void HideMenu()
    {
        GameObject.Find("MenuManager").GetComponent<MenuManager>().DestroyMenu();
    }

    public void DisplayMenu()
    {
        GameObject.Find("MenuManager").GetComponent<MenuManager>().CreateMenu();
    }

    public void GoShop()
    {
        var sceneChanger = this.GetComponent<SceneChanger>();
    }

    public void GoTheater()
    {
        var sceneChanger = this.GetComponent<SceneChanger>();
    }
}
