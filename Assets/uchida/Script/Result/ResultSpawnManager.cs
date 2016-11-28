using UnityEngine;
using System.Collections;
using System;

public class ResultSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject result = null;

    [SerializeField]
    private Timer timer = null;

    private bool isEndOfTheDay = false;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
            // Timerが完成したら書き直す
            if (Input.GetMouseButtonDown(0) && !isEndOfTheDay)
                isEndOfTheDay = true;

            SpawnResult();

            yield return null;
        }
    }

    private void SpawnResult()
    {
        if (!isEndOfTheDay)
            return;

        var result_ = Instantiate(result);
        result_.transform.SetParent(GameObject.Find("Canvas").transform);
        result_.transform.localScale = Vector3.one;
        result_.transform.localPosition = Vector3.zero;
        isEndOfTheDay = false;
    }
}
