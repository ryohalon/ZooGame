using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

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
    float maxPressTime = 2.0f;
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

    void Start()
    {
        isPressed = false;
        isPushed = false;
    }

    //void Update()
    //{
    //    if (maxPressTime < Time.realtimeSinceStartup)
    //    {
    //        onLongPress.Invoke();
    //        nextTime = Time.realtimeSinceStartup + intervalAction;
    //    }
    //}



    public void OnPointerDown(PointerEventData eventData)
    {
        var dragging = GetComponent<DragObject>().dragging;
        if (isPressed || isPushed || pushOnly || dragging)
            return;

        //if (callEventFirstPress)
        //{
        //    onLongPress.Invoke();
        //}
        //maxPressTime = Time.realtimeSinceStartup + intervalAction;

        pressTime += Time.deltaTime;
        if (pressTime > maxPressTime)
            pressTime = maxPressTime;

        if (pressTime == maxPressTime)
            isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var dragging = GetComponent<DragObject>().dragging;
        if (isPressed || isPushed || dragging)
            return;

        isPushed = true;
    }
}