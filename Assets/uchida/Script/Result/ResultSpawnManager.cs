using UnityEngine;
using System.Collections;
using System;

public class ResultSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject result = null;

    private FadeIn fadeIn = null;

    private Timer timer = null;

    private bool isEndOfTheDay = false;
    private GameObject resultWindow = null;

    static private ResultSpawnManager instance = null;

    void Awake()
    {
        if(instance == null)
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

            if(fadeIn.isFadeInEnd)
            {
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
    }
}
