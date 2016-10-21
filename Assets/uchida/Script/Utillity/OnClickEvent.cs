using UnityEngine;
using System.Collections;

public class OnClickEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject window = null;

    public void DeleteWindow()
    {
        Destroy(GameObject.Find(window.name));
    }

    public void CreateWindow()
    {
        Instantiate(window);
    }

    public void GoShop()
    {
        var sceneChanger = this.GetComponent<SceneChanger>();
    }

    public void GoTheater()
    {
        var sceneChanger = this.GetComponent<SceneChanger>();
    }

    public void GoRaise()
    {
        var sceneChanger = this.GetComponent<SceneChanger>();
    }
}
