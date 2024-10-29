using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Car", menuName ="Car/Stat")]
public class CarStat : ScriptableObject
{
    [Header("Vehicle Details")]
    public string Manufacturer;
    public string Model;
    public string Type;

    public string PlayerCarName;
    public CarStatDriveTrain PresetDriveTrain;

    [Header("Engine Specs")]
    public float IdleRPM;
    public float HP;


    public enum CarStatDriveTrain
    {
        RWD,
        FWD,
        AWD,
        FOURWD,
    }

}
