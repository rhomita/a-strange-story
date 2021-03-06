﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    private float xMouseSensivity = 140f;
    private float yMouseSensivity = 160f;
    private float xRotation = 0f;

    private Quaternion newRotation;

    void Start()
    {
        player = GameManager.instance.Player.transform;
    }

    void LateUpdate()
    {
        float yRotation = Input.GetAxis("Mouse X") * xMouseSensivity * Time.deltaTime;
        player.Rotate(Vector3.up * yRotation);

        xRotation -= Input.GetAxis("Mouse Y") * yMouseSensivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        newRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    void FixedUpdate()
    {
        transform.localRotation = newRotation;
    }
}