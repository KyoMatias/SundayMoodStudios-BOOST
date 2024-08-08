using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        engineSpeedVariable = currentRPM;

     roundedValue = Mathf.Round(engineSpeedVariable) / 1000f;


    }


    void Update()
    {
        ApplyGas();
    }

    public void ApplyGas()
    {
        UpdateEngineSpeed();
        throttle = Input.GetAxis("Vertical");
    }

}
