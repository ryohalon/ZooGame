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
        Sound.StopBgm();
        Sound.PlaySe("Ok");
    }
}
