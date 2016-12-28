using UnityEngine;
using System.Collections;
using System;

public class AnimalMover : MonoBehaviour
{
    private Easing easing = null;
    private bool isMove = false;
    private float jumpSpeed = 0.0f;
    [SerializeField]
    private float maxJumpSpeed = 0.0f;
    [SerializeField]
    private float minJumpSpeed = 0.0f;
    private float moveTime = 0.0f;
    private float originPosY = 0.0f;
    [SerializeField]
    private float maxIsJumpNums = 0.0f;
    [SerializeField]
    private float isJumpNums = 0.0f;

    public bool isNotMove = false;

    public void Stop()
    {
        isMove = false;
        isNotMove = true;
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            originPosY,
            transform.localPosition.z);
    }

    void Start()
    {
        easing = GetComponent<Easing>();
        originPosY = transform.localPosition.y;

        StartCoroutine(UpdateAnimalMover());
    }

    private IEnumerator UpdateAnimalMover()
    {
        while(true)
        {
            IsMove();

            Moving();

            yield return null;
        }
    }

    private void Moving()
    {
        if (!isMove)
            return;

        moveTime += Time.deltaTime;
        float posY;
        if (moveTime < 0.5f)
        {
            posY = easing.CubicOut(easing.DelayTime(moveTime, 0.0f, 0.5f),
            originPosY,
            originPosY + jumpSpeed);
        }
        else
        {
            posY = easing.CubicIn(easing.DelayTime(moveTime, 0.5f, 0.5f),
                originPosY + jumpSpeed,
                originPosY);
        }


        transform.localPosition = new Vector3(
            transform.localPosition.x,
            posY,
            transform.localPosition.z);
        if(moveTime >= 1.0f)
        {
            moveTime = 0.0f;
            isMove = false;
        }
    }

    private void IsMove()
    {
        if (isNotMove)
            return;

        if (isMove)
            return;
        
        if (UnityEngine.Random.Range(0.0f, maxIsJumpNums) < isJumpNums)
            return;

        jumpSpeed = UnityEngine.Random.Range(minJumpSpeed, maxJumpSpeed);
        isMove = true;
    }
}
