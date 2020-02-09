using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class CameraScroll : MonoBehaviour
{
    public Transform cameraTransform;
    public float scale = 1;
    public int min = -30;
    public int max = -5;
    public KeyCode keyScroll;

    private void Update()
    {
        float z = Mathf.Clamp(cameraTransform.localPosition.z + scale * Input.mouseScrollDelta.y, min, max);
        if (Input.GetKey(keyScroll))
            cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, cameraTransform.localPosition.y, z);
    }
}
