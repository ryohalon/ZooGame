using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

class Scenario
{
    public string Forcused { get; private set; }

    public string Name { get; private set; }

    public string Message { get; private set; }

    public Scenario(string forcusedmode, string name, string message)
    {
        Forcused = forcusedmode;
        Name = name;
        Message = message;

    }

}

public class TextController : MonoBehaviour
{
    private string[] scenarios;   // シナリオを格納する

    [SerializeField]
    Text uiText;                  // uiTextへの参照を保つ
    [SerializeField]
    Text uiText2;
    [SerializeField]
    Transform container;

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;   // 1文字の表示にかかる時間

    //private string currentText = string.Empty;   // 現在の文字列
    private float timeUntilDisplay = 0;          // 表示にかかる時間
    private float timeElapsed = 1;               // 文字列の表示を開始した時間
    //private int currentLine = 0;                 // 現在の行番号
    //private int lastUpdateCharacter = -1;        // 表示中の文字数

    // 文字の表示が完了しているかどうか
    public bool IsCompleteDisplayText
    {
        get { return Time.time > timeElapsed + timeUntilDisplay; }
    }

    void Start()
    {
        StartCoroutine(ScenarioIterator());
        SoundManager.Instance.PlayBGM((int)BGMList.ITEM_LIST);
    }

    private IEnumerator ScenarioIterator()
    {
        var scenario = LoadScenario();
        foreach (var line in scenario)
        {
            for (int i = 0; i < container.childCount; i++)
            {
                var c = container.GetChild(i);
                //c.gameObject.name;
                if (c.gameObject.name == line.Forcused)
                {
                    //c.gameObject.SetActive(true);
                    var image = c.gameObject.GetComponent<Image>();
                    image.color = new Color(1, 1, 1, 1);

                }
                else
                {

                    //c.gameObject.SetActive(false);
                    var image = c.gameObject.GetComponent<Image>();
                    image.color = new Color(0f, 0f, 0f, 0.65f);


                }
            }
            //yield return StartCoroutine(LineIterator(line.Name));
            yield return StartCoroutine(LineIterator(line.Message));             // 一文字ずつの表示
            //yield return StartCoroutine(LineIterator(line.Name));
            while (!Input.GetMouseButtonDown(0)) { yield return null; }  // 文字を次の行に行かせるためのクリック待ち
        }
        SoundManager.Instance.StopBGM();
        SceneManager.LoadScene("GameMain");     // scenarioが最後の行まで行ったら移動先のシーンに移動
    }

    private IEnumerator LineIterator(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            var startTime = Time.time;
            var t = 0F;
            uiText.text = line.Substring(0, i);
            yield return null;

            while (t < intervalForCharacterDisplay)
            {
                t += Time.time - startTime;

                if (Input.GetMouseButtonDown(0))
                {
                    uiText.text = line;
                    SoundManager.Instance.PlaySE((int)SEList.OK);
                    yield break;
                }
                yield return null;
            }
        }
    }

    private IEnumerable<Scenario> LoadScenario()
    {
        int num = GameObject.Find("Player").GetComponent<PlayerStatusManager>().StoryLevel;

        var ta = Resources.Load<TextAsset>("scenario" + num.ToString());
        foreach(var line in ta.text.Split('\n'))
        {
            
            var s = line.Split(',');

            Debug.Log(s[0]);

            uiText2.text = s[1];
            yield return new Scenario(s[0], s[1],s[2]);
        }
    }
}