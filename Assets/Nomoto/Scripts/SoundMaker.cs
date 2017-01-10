using UnityEngine;
using System.Collections;

// Soundの登録をするクラスです
// 呼ぶ前に必ずここに登録してください

//書き方について
//追加したいSoundをまずResourcesのSoundsに入れてください
//次に、下のAwakeにLoadBgmまたはLoadSeで設定してください
//第一引数がKeyで、第二引数はSoundsの中の名前です。
//Sound.PlayBgm または　Sound.PlaySeで再生できます
//音を止めたい場合は、Stopを呼んでください


public class SoundMaker : MonoBehaviour
{
    void Awake()
    {
        Sound.LoadBgm("ShopBgm", "Shop");
        Sound.LoadBgm("GameMainBgm", "GameMain");
        Sound.LoadBgm("GameMainNightBgm", "GameMainNight");
        Sound.LoadSe("Ok","Ok");
        Sound.LoadSe("Close","Close");
        Sound.LoadSe("brush", "TraningSE/Rear_brush");
        Sound.LoadSe("bite", "TraningSE/Rear_bite");
        Sound.LoadSe("loveup", "TraningSE/Rear_loveup");
        Sound.LoadSe("dontLike", "TraningSE/Rear_hatefood");
        Sound.LoadSe("like", "TraningSE/Rear_like");
        Sound.LoadSe("cash", "ShopSE/Shop_cash");
        Sound.LoadSe("wood", "GameMainSE/Main_wood");
        Sound.LoadSe("put", "GameMainSE/Main_put");
        Sound.LoadSe("swipe", "GameMainSE/Main_swipe");
    }
}