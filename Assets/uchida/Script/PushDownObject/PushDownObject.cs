using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PushDownObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    /// <summary>
    /// 押しっぱなし時に呼び出すイベント
    /// </summary>
    //public UnityEvent onLongPress = new UnityEvent();
    /// <summary>
    /// 押しっぱなし判定の間隔（この間隔毎にイベントが呼ばれる）
    /// </summary>
    //public float intervalAction = 2.0f;
    // 押下開始時にもイベントを呼び出すフラグ
    //public bool callEventFirstPress;

    // 次の押下判定時間
    float maxPressTime = 1.0f;
    float pressTime = 0.0f;

    public bool pushOnly = false;

    /// <summary>
    /// 押下状態
    /// </summary>
    public bool isPressed
    {
        get;
        set;
    }
    public bool isPushed
    {
        get;
        set;
    }

    public bool pressStart
    {
        get;
        set;
    }

    void Start()
    {
        isPressed = false;
        isPushed = false;
        pressStart = false;

        if (!pushOnly)
            StartCoroutine(UpdateOnDown());
    }

    private IEnumerator UpdateOnDown()
    {
        while(true)
        {
            if (pressStart)
            {
                Debug.Log(pressTime);
                pressTime += Time.deltaTime;
                if (pressTime > maxPressTime)
                    pressTime = maxPressTime;

                if (pressTime == maxPressTime)
                {
                    pressStart = false;
                    isPressed = true;
                }
            }

            yield return null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var dragging = GetComponent<DragObject>().dragging;
        if (isPushed || pushOnly || dragging)
            return;

        Debug.Log("俺は今押しているぅ～！");
        pressStart = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var dragging = GetComponent<DragObject>().dragging;
        if (pressTime == maxPressTime || isPushed || dragging)
            return;

        isPushed = true;
        pressStart = false;
    }
}