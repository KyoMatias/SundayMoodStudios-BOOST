using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum R_TunePowerName
{
    Aster,
    Meteor,
    Comet,
    Nebula,
    Pulsar,
    Quasar,
    Supernova,
    Horizon,
    Singularity,
    Galactic,
}

[CreateAssetMenu(fileName = "RivalComponent", menuName = "Rival")]
public class RivalStats : ScriptableObject
{
    public string R_Name;
    [TextArea]
    public string R_Description;
    public string R_Clan;
    public string Car;
    public int CarHp;
    public int CarUpgradeLvl;
    public char CarRank;
    public string TunePower;
    public R_TunePowerName TunePowerType;


    private void OnEnable()
    {
        CalculateTunePower();
    }
    
    private void CalculateTunePower()
    {
        switch (TunePowerType)
        {
            case R_TunePowerName.Aster:
                TunePower = "Aster";
                break;
            case R_TunePowerName.Meteor:
                TunePower = "Meteor";
                break;
            case R_TunePowerName.Comet:
                TunePower = "Comet";
                break;
            case R_TunePowerName.Nebula:
                TunePower = "Nebula";
                break;
            case R_TunePowerName.Pulsar:
                TunePower = "Pulsar";
                break;
            case R_TunePowerName.Quasar:
                TunePower = "Quasar";
                break;
            case R_TunePowerName.Supernova:
                TunePower = "Supernova";
                break;
            case R_TunePowerName.Horizon:
                TunePower = "Horizon";
                break;
            case R_TunePowerName.Singularity:
                TunePower = "Singularity";
                break;
            case R_TunePowerName.Galactic:
                TunePower = "Galactic";
                break;
            default:
                break;
        }
    }
}
