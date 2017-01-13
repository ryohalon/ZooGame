using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ResultSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject result = null;

    private FadeIn fadeIn = null;

    private Timer timer = null;

    private PlayerStatusManager player = null;

    [SerializeField]
    private GameObject colorFade = null;

    private bool isEndOfTheDay = false;
    private GameObject resultWindow = null;

    static private ResultSpawnManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        timer = GameObject.Find("Timer").GetComponent<Timer>();
        fadeIn = GameObject.Find("FadeIn").GetComponent<FadeIn>();
        player = GameObject.Find("Player").GetComponent<PlayerStatusManager>();
        isEndOfTheDay = false;
    }

    void Start()
    {
        StartCoroutine(UpdateResultSpawnManager());
    }

    private IEnumerator UpdateResultSpawnManager()
    {
        while (true)
        {
            yield return null;
            if (!isEndOfTheDay && resultWindow != null) continue;

            if (fadeIn.isFadeInEnd)
            {
                if(player.StoryLevel == 0)
                {
                    player.StoryLevel++;
                    var colorFade_ = Instantiate(colorFade);
                    colorFade_.transform.SetParent(GameObject.Find("Canvas").transform);
                    colorFade_.GetComponent<RectTransform>().localPosition = Vector3.zero;
                    colorFade_.GetComponent<RectTransform>().localScale = Vector3.one;
                    colorFade_.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                }

                if (timer.isEndDay)
                    isEndOfTheDay = true;

                SpawnResult();
            }
        }
    }

    private void SpawnResult()
    {
        if (!isEndOfTheDay)
            return;
        if (resultWindow != null)
            return;

        resultWindow = Instantiate(result);
        resultWindow.transform.SetParent(GameObject.Find("Canvas").transform);
        resultWindow.transform.localScale = Vector3.one;
        resultWindow.transform.localPosition = Vector3.zero;
        isEndOfTheDay = false;

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameMain")
        {
            var cageListManager = GameObject.Find("CageListManager").GetComponent<CageListManager>();
            foreach (var cage in cageListManager.cageList)
            {
                cage.GetComponent<AnimalMover>().Stop();
            }

            var peopleManager = GameObject.Find("PeopleManager").GetComponent<PeopleManager>();
            peopleManager.PeopleDelete();
        }
    }
}
