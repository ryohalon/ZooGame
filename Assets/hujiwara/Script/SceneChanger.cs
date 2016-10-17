using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string NextSceneName;

    void OnMouseDown()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
