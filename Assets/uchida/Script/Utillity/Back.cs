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
                    GameObject.Find("CageListManager").GetComponent<CageListManager>().touchType = CageListManager.TouchType.NONE;
                    GetComponent<OnClickEvent>().DeleteWindow();
                }
            }

            yield return null;
        }
    }
}
