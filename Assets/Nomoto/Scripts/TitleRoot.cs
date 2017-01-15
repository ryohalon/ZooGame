using UnityEngine;
using System.Collections;

public class TitleRoot : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.PlayBGM((int)BGMList.SHOP);
    }

    public void PushButton()
    {
        SoundManager.Instance.PlaySE((int)SEList.OK);
        SoundManager.Instance.StopBGM();
    }
}
