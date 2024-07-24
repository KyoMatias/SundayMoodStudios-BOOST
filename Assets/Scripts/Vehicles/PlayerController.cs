 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    public enum Drivetype
    {
        RearWheel,
        FrontWheel,
        AllWheel,
        FourWheel,
    }

    [SerializeField] private Drivetype currentDrivetype;

    public enum DriveMode
    {
        EngineOff,
        EngineOn,

        Cutscene,
        Sequenced,

        Burnout,

        Race,

        Finish
    }

    [HideInInspector] public float CarSpeed = 0;
    [HideInInspector] public float EngineRevolutions = 0;
    [SerializeField] public string vehicleName {get ; private set;}
}
