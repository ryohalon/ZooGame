using UnityEngine;
using System.Collections;

public class SetActive : MonoBehaviour
{
    public GameObject test;

    public void Set()
    {
        var isActive = test.activeSelf;

        if(isActive == false)
        {
            test.SetActive(true);
        }
        else
        {
            test.SetActive(false);
        }
    }
}