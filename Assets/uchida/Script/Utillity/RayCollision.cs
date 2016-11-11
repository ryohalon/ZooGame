using UnityEngine;
using System.Collections;

public class RayCollision : MonoBehaviour
{
    public Vector3 HitRayPosCameraToMouse()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit))
            return hit.transform.position;

        return Vector3.zero;
    }
}
