using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float horizontalSpeed = 1;
    public float verticalSpeed = 1;
    public Vector3 rotate;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rotate.y = rotate.y + horizontalSpeed * Input.GetAxis("Mouse X");
            if (rotate.y > 360) rotate.y -= 360;
            if (rotate.y < 0) rotate.y += 360;
            rotate.x = Mathf.Clamp(rotate.x - verticalSpeed * Input.GetAxis("Mouse Y"), 0, 80);
            transform.rotation = Quaternion.Euler(rotate);
        }
    }
}
