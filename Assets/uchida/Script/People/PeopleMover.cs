using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PeopleMover : MonoBehaviour
{
    public bool isMoveEnd = false;

    float moveTime = 0.0f;
    public List<float> moveTakeTimeList = new List<float>();
    public List<Vector2> movePointList = new List<Vector2>();
    int moveCount = 0;
    Easing easing = null;
    public Vector2 start_pos = Vector2.zero;

    void Start()
    {
        easing = GetComponent<Easing>();

        StartCoroutine(UpdatePeopleMover());
    }

    private IEnumerator UpdatePeopleMover()
    {
       while(true)
        {
            Moving();

            yield return null;
        }
    }

    private void Moving()
    {
        if (isMoveEnd)
            return;

        moveTime += Time.deltaTime;
        float pos_x = easing.Linear(easing.DelayTime(moveTime, 0.0f, moveTakeTimeList[moveCount]), start_pos.x, movePointList[moveCount].x);
        float pos_y = easing.Linear(easing.DelayTime(moveTime, 0.0f, moveTakeTimeList[moveCount]), start_pos.y, movePointList[moveCount].y);

        transform.localPosition = new Vector3(pos_x, pos_y, 0.0f);
        if(moveTime >= 1.0f)
        {
            start_pos = movePointList[moveCount];
            moveCount++;
            if (moveCount >= movePointList.Count)
                isMoveEnd = true;
        }
    }
}
