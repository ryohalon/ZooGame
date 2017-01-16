using UnityEngine;
using System.Collections;

public class OnClickEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject window = null;
    
    public void DeleteWindow()
    {
        Destroy(GameObject.Find(window.name));
        SoundManager.Instance.PlaySE((int)SEList.CLOSE);
    }

    public void CreateWindow()
    {
        if (GameObject.Find(window.name + "(Clone)") != null)
            return;

        SoundManager.Instance.PlaySE((int)SEList.OK);

        Instantiate(window);
    }
}
