using UnityEngine;
using System.Collections;

public class TitleRoot : MonoBehaviour
{
    void Start()
    {
        //Sound.LoadBgm("ShopBgm", "Shop");
        Sound.PlayBgm("GameMainBgm");
    }

    public void PushButton()
    {
        Sound.StopBgm();
        Sound.PlaySe("Ok");
    }
}
