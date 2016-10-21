using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string NextSceneName;

    public void TouchButton()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
