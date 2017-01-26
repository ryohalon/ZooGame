using UnityEngine;
using System.Collections;

public class TitleRoot : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(450, 800, false, 60);

    }

    void Start()
    {
        GameObject.Find("AnimalList").GetComponent<AnimalStatusCSV>().Save();
        SoundManager.Instance.PlayBGM((int)BGMList.SHOP);
    }

    public void PushButton()
    {
        SoundManager.Instance.PlaySE((int)SEList.OK);
        SoundManager.Instance.StopBGM();
    }
}
