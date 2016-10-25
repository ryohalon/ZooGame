using UnityEngine;
using System.Collections;

public class MenuSetup : MonoBehaviour
{
    void Start()
    {
        this.transform.SetParent(GameObject.Find("Canvas").transform);
        this.transform.localPosition = Vector3.zero;
    }
}
