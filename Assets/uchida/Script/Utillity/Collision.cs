using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour
{
    public float size = 0.0f;

    void Start()
    {
        size = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public bool IsHit(Vector3 touchPos)
    {
        if (touchPos.z != transform.position.z)
            return false;

        return (touchPos.x > transform.position.x - size / 2.0f &&
            touchPos.x < transform.position.x + size / 2.0f &&
            touchPos.y > transform.position.y - size / 2.0f &&
            touchPos.y < transform.position.y + size / 2.0f);
    }
}
