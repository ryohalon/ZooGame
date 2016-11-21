using UnityEngine;
using System.Collections;
using System;

public class MenuWindowManager : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(UpdateWindow());
    }

    private IEnumerator UpdateWindow()
    {
        while(true)
        {
            SelectButton();

            yield return null;
        }
    }

    private void SelectButton()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        var back = transform.GetChild(0).gameObject;
        if (back.GetComponent<Collision>().IsHit(GetComponent<RayCollision>().HitRayPosCameraToMouse()))
        {
            Destroy(this.gameObject);
            return;
        }


        var shop = transform.GetChild(2).gameObject;
        if (shop.GetComponent<Collision>().IsHit(GetComponent<RayCollision>().HitRayPosCameraToMouse()))
        {
            GetComponent<SceneChanger>().NextSceneName = "Shop";
            GetComponent<SceneChanger>().TouchButton();
            return;
        }

        var mochinomo = transform.GetChild(3).gameObject;
        if (mochinomo.GetComponent<Collision>().IsHit(GetComponent<RayCollision>().HitRayPosCameraToMouse()))
        {
            //Instantiate(Mochimono);
            Destroy(this.gameObject);
            return;
        }

        var profile = transform.GetChild(4).gameObject;
        if (profile.GetComponent<Collision>().IsHit(GetComponent<RayCollision>().HitRayPosCameraToMouse()))
        {
            //Instantiate(Profile);
            Destroy(this.gameObject);
            return;
        }

        var option = transform.GetChild(5).gameObject;
        if (option.GetComponent<Collision>().IsHit(GetComponent<RayCollision>().HitRayPosCameraToMouse()))
        {
            GetComponent<SceneChanger>().NextSceneName = "Option";
            GetComponent<SceneChanger>().TouchButton();
            return;
        }

    }
}
