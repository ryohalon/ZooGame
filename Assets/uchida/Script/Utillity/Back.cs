using UnityEngine;
using System.Collections;
using System;

public class Back : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(UpdateBack());
    }

    private IEnumerator UpdateBack()
    {
        while (true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if(GetComponent<Collision>().IsHit(GetComponent<RayCollision>().HitRayPosCameraToMouse()))
                {
                    GameObject.Find("Cage2ListManager").GetComponent<Cage2ListManager>().touchType = Cage2ListManager.TouchType.NONE;
                    GetComponent<OnClickEvent>().DeleteWindow();
                }
            }

            yield return null;
        }
    }
}
