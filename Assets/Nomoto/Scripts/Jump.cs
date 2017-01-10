using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    Vector3 pos;

    bool isJump = false;
    [SerializeField]
    float jumpSpeed = 10;
    [SerializeField]
    float jumpCount = 0.0f;

    [SerializeField]
    float gravity = 0.8f;
    void Start()
    {
        pos = gameObject.transform.localPosition;
    }

    void Update()
    {
        if (isJump == false)
            isJump = true;

        if(isJump == true)
        {


            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
                                                             gameObject.transform.localPosition.y + jumpSpeed * Time.deltaTime - jumpCount * gravity,
                                                             gameObject.transform.localPosition.z);

            jumpCount += Time.deltaTime;

            if(gameObject.transform.localPosition.y  < pos.y)
            {
                gameObject.transform.localPosition = new Vector3(pos.x,
                                                                 pos.y,
                                                                 pos.z);
                isJump = false;
                jumpCount = 0.0f;
            }
        }
    }
}
