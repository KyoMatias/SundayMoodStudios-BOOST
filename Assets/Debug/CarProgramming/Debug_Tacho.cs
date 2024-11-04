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
    private float startpos = -20f;
    private float endpos = 480f;
    private float desirepos;
    private float engineSpeed;
    private float needlespeed;
    private float maxSpeed;
    private float speed;
    private float speedNormalized;
    private float totalAG;

    private Engine engine;

    void Awake()
    {
        needle = transform.Find("Needle");

        speed = 0f;
        maxSpeed = 10;

        engine = FindAnyObjectByType<Engine>();
    }

    private void Start() {
        needlespeed = startpos;
    }
    void Update()
    {
        //EngineInput();
        engineSpeed = engine.roundedValue;
        float value = engineSpeed / needlespeed;
        desirepos = startpos - endpos;
        needle.eulerAngles = new Vector3(0,0, startpos - value * desirepos);
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

        speed = Mathf.Clamp(speed,0f, maxSpeed);
    }

    private float GetRotation()
    {
        float totalAngle = NullSpeed - MaxAngle;

        speedNormalized = speed / maxSpeed;
        return NullSpeed - speedNormalized * totalAngle;
    }
}
