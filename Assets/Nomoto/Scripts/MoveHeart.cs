using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveHeart : MonoBehaviour
{
    float activeTime = 2.5f;

    [SerializeField]
    public Vector3 position;

    [SerializeField]
    public Vector3 speed;

    public void Make()
    {
        position = GetComponent<RectTransform>().position;
        GetComponent<RectTransform>().position = position;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        speed = new Vector3(screenSize.x / 20.0f,screenSize.y / 20.0f, 0.0f);
    }

    void Update()
    {
        position += new Vector3(speed.x * Time.deltaTime * Mathf.Sin(activeTime * 5), speed.y * Time.deltaTime, 0.0f);
        this.gameObject.GetComponent<RectTransform>().position = position;
        activeTime -= Time.deltaTime;
        if (activeTime > 0) return;
        Destroy(gameObject);
    }
}