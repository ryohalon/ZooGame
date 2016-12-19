using UnityEngine;
using System.Collections;
using System;

public class BalloonUpper2 : MonoBehaviour
{
    private Timer timer = null;
    private float upTime = 0.0f;
    [SerializeField]
    private float upTakeTimeX = 1.0f;
    [SerializeField]
    private float upTakeTimeY = 1.0f;
    [SerializeField]
    public Vector2 start_pos = new Vector2(-250.0f, -300.0f);
    [SerializeField]
    public Vector2 end_pos = new Vector2(300.0f, 500.0f);

    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();

        if (timer.isBalloonUp)
            StartCoroutine(UpdateBalloon2());
        else
            Destroy(gameObject);
    }

    private IEnumerator UpdateBalloon2()
    {
        while (true)
        {
            var easing = GetComponent<Easing>();
            upTime += Time.deltaTime;

            float pos_y = 0.0f;
            if (upTime < upTakeTimeY / 2.0f)
            {
                pos_y = easing.QuadOut(
                    easing.DelayTime(upTime, 0.0f, upTakeTimeY / 2.0f),
                    start_pos.y,
                    end_pos.y - (Mathf.Abs(start_pos.y - end_pos.y) / 2.0f));
            }
            else
            {
                pos_y = easing.QuadIn(
                    easing.DelayTime(upTime, upTakeTimeY / 2.0f, upTakeTimeY),
                    end_pos.y - (Mathf.Abs(start_pos.y - end_pos.y) / 2.0f),
                    end_pos.y);
            }
            float pos_x = easing.QuadInOut(easing.DelayTime(upTime, 0.0f, upTakeTimeX), start_pos.x, end_pos.x);

            transform.localPosition = new Vector3(pos_x, pos_y, 0.0f);

            if (pos_y == end_pos.y)
                Destroy(gameObject);

            yield return null;
        }
    }
}
