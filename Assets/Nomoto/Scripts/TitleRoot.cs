using UnityEngine;
using System.Collections;

public class TitleRoot : MonoBehaviour
{

    void Start()
    {
        Sound.PlayBgm("GameMainBgm");
    }

    public void PushButton()
    {
        Sound.StopBgm();
        Sound.PlaySe("Ok");
    }

}
