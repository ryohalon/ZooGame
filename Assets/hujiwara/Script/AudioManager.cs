using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    // ボリューム保存用key
    private const string BGM_VOLUME_KEY = "BGM_VOLUME_KEY";
    private const string SE_VOLUME_KEY = "SE_VOLUME_KEY";
    // ボリュームデフォルト値
    private const float BGM_VOLUME_DEFAULT = 1.0f;
    private const float SE_VOLUME_DEFAULT = 1.0f;

    // BGMがフェードるのにかかる時間
    public const float BGM_FADE_SPEED_RATE_HIGH = 0.9f;
    public const float BGM_FADE_SPEED_RATE_LOW = 0.3f;
    private float _bgmFadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH;

    // 次に流すBGM, SE
    private string _nextBGMName;
    private string _nextSEName;

    // BGMをフェードアウト中か
    private bool _isFadeOut = false;

    // BGM,SEでそれぞれ音量を変えられるように、
    // オーディオソースは二つに分ける
    public AudioSource AttachBGMSource, AttachSESource;

    // 全てのAudioを保持
    private Dictionary<string, AudioClip> _bgmDic, _seDic;

    // Start関数より前に実行されるらしいけど詳しくは調べ中
    // 後でStart関数に書き直すかも
    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // リソースフォルダから全てのBGM,SEのファイルを読み込みセット
        // (Dictionaryは多分mapみたいなやつ)
        _bgmDic = new Dictionary<string, AudioClip>();
        _seDic = new Dictionary<string, AudioClip>();
        // AssetsにResourcesフォルダが無い場合は作成
        // Resources.LoadAllはResourcesフォルダ以下のファイルを全て取得
        // LoadAll(.../...)にする事により、
        // Resourcesフォルダ以下のフォルダの全ファイルも取得可能
        object[] bgmList = Resources.LoadAll("Audio/BGM");
        object[] seList = Resources.LoadAll("Audio/SE");

        foreach (AudioClip bgm in bgmList)
        {
            _bgmDic[bgm.name] = bgm;
        }
        foreach(AudioClip se in seList)
        {
            _seDic[se.name] = se;
        }
    }

    void Start()
    {
        AttachBGMSource.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEFAULT);
        AttachSESource.volume = PlayerPrefs.GetFloat(SE_VOLUME_KEY, SE_VOLUME_DEFAULT);
    }

    //==================================================
    // SE
    //==================================================
    public void PlaySE(string seName, float delay = 0.0f)
    {
        // パスが違ったり、この名前のSEが無くてもゲーム再生、DebugにLogが出る
        if(!_seDic.ContainsKey(seName))
        {
            Debug.Log(seName + "という名前のSEがありません。");
            return;
        }

        _nextSEName = seName;
        // 指定した秒数後にメソッド（関数）を呼び出す
        Invoke("DelayPlaySE", delay);
    }

    private void DelayPlaySE()
    {
        // PlayOneShot 一回だけ鳴らすやつ
        AttachSESource.PlayOneShot(_seDic[_nextSEName] as AudioClip);
    }


    //==================================================
    // BGM
    //==================================================
    public void PlayBGM(string bgmName, float fadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH)
    {
        // パスが違ったり、この名前のBGMが無くてもゲーム再生、DebugにLogが出る
        if (!_bgmDic.ContainsKey(bgmName))
        {
            Debug.Log(bgmName + "という名前のBGMがありません。");
            return;
        }

        // 現在BGMが流れていない場合はBGMを流す
        if(!AttachBGMSource.isPlaying)
        {
            _nextBGMName = "";
            AttachBGMSource.clip = _bgmDic[bgmName] as AudioClip;
            AttachBGMSource.Play();
        }
        // BGMが流れている場合、現在のBGMをフェードアウトさせてから次のBGMを流す
        else if(AttachBGMSource.clip.name != bgmName)
        {
            _nextBGMName = bgmName;
            FadeOutBGM(fadeSpeedRate);
        }
    }

    // BGMを即座に止める
    public void StopBGM()
    {
        AttachBGMSource.Stop();
    }

    // BGMをフェードアウトさせる
    public void FadeOutBGM(float  fadeSpeedRate = BGM_FADE_SPEED_RATE_LOW)
    {
        _bgmFadeSpeedRate = fadeSpeedRate;
        _isFadeOut = true;
    }

    private void Update()
    {
        if(!_isFadeOut)
        {
            return;
        }

        AttachBGMSource.volume -= Time.deltaTime * _bgmFadeSpeedRate;
        if(AttachBGMSource.volume <= 0)
        {
            AttachBGMSource.Stop();
            AttachBGMSource.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEFAULT);
            _isFadeOut = false;

            if(!string.IsNullOrEmpty(_nextBGMName))
            {
                PlayBGM(_nextBGMName);
            }
        }
    }

    //==================================================
    // 音量変更(BGMとSE分けたバージョン)
    //==================================================
    public void ChangeBGMVolume(float BGMVolume)
    {
        AttachBGMSource.volume = BGMVolume;

        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, BGMVolume);
    }

    public void ChangeSEVolume(float SEVolume)
    {
        AttachSESource.volume = SEVolume;

        PlayerPrefs.SetFloat(SE_VOLUME_KEY, SEVolume);
    }
}
