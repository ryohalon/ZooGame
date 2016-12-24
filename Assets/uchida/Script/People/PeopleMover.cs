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
    int moveCount = 1;
    Easing easing = null;
    private Vector2 start_pos = Vector2.zero;
    Vector2 canvasSize = Vector2.zero;

    void Start()
    {
        canvasSize = transform.parent.GetComponent<RectTransform>().rect.size / 2;
        var pixelSize = transform.parent.GetComponent<Canvas>().pixelRect.size;
        var referenceResolution = transform.parent.GetComponent<RectTransform>().rect.size;
        Vector2 differenceRatio;
        differenceRatio.x = referenceResolution.x / pixelSize.x;
        differenceRatio.y = referenceResolution.y / pixelSize.y;

        for(int i = 0; i < movePointList.Count; i++)
        {
            movePointList[i] = new
                //Vector2(movePointList[i].x - canvasSize.x * differenceRatio.x,
                //movePointList[i].y - canvasSize.y * differenceRatio.y);
                Vector2(movePointList[i].x - canvasSize.x,
                movePointList[i].y - canvasSize.y);
        }

        start_pos = movePointList[0];
        transform.localPosition = new Vector3(start_pos.x, start_pos.y, 0.0f);
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
        if(easing.DelayTime(moveTime, 0.0f, moveTakeTimeList[moveCount]) == 1.0f)
        {
            moveTime = 0.0f;
            start_pos = movePointList[moveCount];
            moveCount++;
            if (moveCount >= movePointList.Count)
                isMoveEnd = true;
        }
    }
}
