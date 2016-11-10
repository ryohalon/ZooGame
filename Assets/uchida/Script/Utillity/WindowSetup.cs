using UnityEngine;
using System.Collections;

public class WindowSetup : MonoBehaviour
{
    void Start()
    {
        this.transform.SetParent(GameObject.Find("Canvas").transform);
        this.transform.localPosition = Vector3.zero;
        //this.GetComponent<RectTransform>().transform.position = new Vector3(0.0f, 0.0f, 30.0f);
        this.transform.localScale = Vector3.one;
    }
}
