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
        if (GameObject.Find(window.name + "(Clone)") != null)
            return;
        Instantiate(window);
    }
}
