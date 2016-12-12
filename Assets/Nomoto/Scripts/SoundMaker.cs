using UnityEngine;
using System.Collections;

// Soundの登録をするクラスです
// 呼ぶ前に必ずここに登録してください

public class SoundMaker : MonoBehaviour
{
    void Start()
    {
        Sound.LoadBgm("TitleBgm", "Title");
        Sound.LoadSe("Ok", "Ok");

        Sound.PlayBgm("TitleBgm");
    }
}