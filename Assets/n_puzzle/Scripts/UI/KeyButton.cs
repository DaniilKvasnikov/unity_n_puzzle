using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class KeyButton : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private bool loop;
    
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(key))
            Down();
    }

    private void FixedUpdate()
    {
        if (loop && Input.GetKey(key))
            Down();
    }
    
    private void Down()
    {
        button.onClick.Invoke();
    }

}
