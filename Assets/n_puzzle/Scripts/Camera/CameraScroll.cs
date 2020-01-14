using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class CameraScroll : MonoBehaviour
{
    public Transform cameraTransform;
    public float scale = 1;

    private void Update()
    {
        float z = Mathf.Clamp(cameraTransform.localPosition.z + scale * Input.mouseScrollDelta.y, -30, -3);
        cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, cameraTransform.localPosition.y, z);
    }
}
