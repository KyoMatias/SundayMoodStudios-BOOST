using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_Tacho : MonoBehaviour
{
    private const float MaxAngle = 90;
    private const float NullSpeed = 340;

    private Transform needle;

    private float maxSpeed;
    private float speed;

    private Engine engine;

    void Awake()
    {
        needle = transform.Find("Needle");

        speed = 0f;
        maxSpeed = 10;

        engine = FindAnyObjectByType<Engine>();
    }

    void Update()
    {
        //EngineInput();

        needle.eulerAngles = new Vector3(0,0, GetRotation());
    }

    private void EngineInput()
    {

            speed += engine.roundedValue * Time.deltaTime;
        
            float dec = speed;
            speed -= dec * Time.deltaTime;
        /*

        if (Input.GetKey(KeyCode.DownArrow)) {
            float brake = 1f;
            speed -= brake * Time.deltaTime;
        }*/

        //speed = Mathf.Clamp(speed,0f, maxSpeed);
    }

    private float GetRotation()
    {
        float totalAngle = NullSpeed - MaxAngle;

        float speednormalized = speed / maxSpeed;
        return NullSpeed - speednormalized * totalAngle;
    }
}
