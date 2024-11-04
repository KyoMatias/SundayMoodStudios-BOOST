using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Engine : MonoBehaviour
{
    
    // Idle engine speed in RPM
    public float idleRPM = 900f;

    // Maximum engine speed in RPM
    public float maxRPM = 10000f;

    // Horsepower multiplier
    public float horsepower = 1f;

    // Throttle input (0-1)
    public float throttle = 0f;

    // Current engine speed in RPM
    private float currentRPM = 0f;

    public float engineSpeedVariable;

    public float roundedValue;


    [Header("Turbo")]
    [SerializeField] private AudioSource turboLowStage;
    [SerializeField] private AudioSource turboHighStage;
    [SerializeField]private float tLS_Trigger;
    [SerializeField]private float tHS_Trigger;
    private bool tLS_Clicked;
    private bool tHS_Clicked;



 private void Start() {
 }
    // Calculate engine speed based on throttle input
    public void UpdateEngineSpeed()
    {
        // Clamp throttle input to [0, 1] range
        throttle = Mathf.Clamp01(throttle);

        // Calculate the target RPM based on throttle input
        float targetRPM = idleRPM + (throttle * (maxRPM - idleRPM));

        // Gradually increase the current RPM towards the target RPM
        currentRPM = Mathf.Lerp(currentRPM, targetRPM, Time.deltaTime * horsepower);

        // Update the engine speed variable
        // (e.g., to drive an animation or audio effect)
        engineSpeedVariable = Mathf.Ceil(currentRPM) / 1f;

     roundedValue = (float)Math.Round(engineSpeedVariable,2) / 1000f;
     roundedValue.ToString("#.##");
     String.Format("{0:0.00}",roundedValue);//add a '0' to each 10 to increase the decimal places
     //Mathf.Round(engineSpeedVariable) / 1000f;


    }


    void Update()
    {
        ApplyGas();
        TurboWatch();
    }

    public void ApplyGas()
    {
        UpdateEngineSpeed();
        throttle = Input.GetAxis("Vertical");
    }

    void TurboWatch()
    {
        float currentRPM = engineSpeedVariable;
        if(currentRPM < tHS_Trigger &&  !tHS_Clicked)
        {
            PlayLowBOV();
        }

    }

    void PlayLowBOV()
    {
        if(turboLowStage != null)
        {
            Debug.Log("Low BOV Playing");
            turboLowStage.Play();
            tLS_Clicked = true;
        }
        else
        {
            Debug.LogError("No Audio");
        }
    }

}
