using UnityEngine;
using System.Collections;
using System;

public class BalloonUpper : MonoBehaviour
{
    private Timer timer = null;
    public float upSpeeed = 10.0f;

    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();

        transform.localPosition = new Vector3(
            UnityEngine.Random.Range(-120.0f, 120.0f),
            UnityEngine.Random.Range(-400.0f, -450.0f),
            0.0f);

        upSpeeed = UnityEngine.Random.Range(upSpeeed / 2.0f, upSpeeed * 1.5f);

        if (timer.isBalloonUp)
            StartCoroutine(UpdateBalloon());
        else
            Destroy(gameObject);
    }

    private IEnumerator UpdateBalloon()
    {
        while(true)
        {
            transform.localPosition += Vector3.up * upSpeeed;

            if (transform.localPosition.y >= 1000.0f)
                Destroy(gameObject);
            
            yield return null;
        }
    }
}
