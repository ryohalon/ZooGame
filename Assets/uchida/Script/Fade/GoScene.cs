using UnityEngine;
using System.Collections;

public class GoScene : MonoBehaviour
{
    private ColorFade colorFade = null;

    void Start()
    {
        colorFade = GetComponent<ColorFade>();
    }

    void Update()
    {
        if (colorFade.isFadeEnd)
        {
            GetComponent<SceneChanger>().NextSceneName = "karakida";
            GetComponent<SceneChanger>().TouchButton();
        }
    }
}
