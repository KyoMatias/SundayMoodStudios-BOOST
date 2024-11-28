using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RivalComponent", menuName = "Rival")]
public class RivalStats : ScriptableObject
{
    public string R_Name;
    public string R_Description;
    public string R_Clan;
    public string Car;
    public int CarHp;
    public int CarUpgradeLvl;
    public char CarRank;
    public string TunePower;
    public TunePowerName TunePowerType;
    
    public enum TunePowerName
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

    private void OnEnable()
    {
        CalculateTunePower();
    }

    private void CalculateTunePower()
    {
        switch (TunePowerType)
        {
            case TunePowerName.Aster:
                TunePower = "Aster";
                break;
            case TunePowerName.Meteor:
                TunePower = "Meteor";
                break;
            case TunePowerName.Comet:
                TunePower = "Comet";
                break;
            case TunePowerName.Nebula:
                TunePower = "Nebula";
                break;
            case TunePowerName.Pulsar:
                TunePower = "Pulsar";
                break;
            case TunePowerName.Quasar:
                TunePower = "Quasar";
                break;
            case TunePowerName.Supernova:
                TunePower = "Supernova";
                break;
            case TunePowerName.Horizon:
                TunePower = "Horizon";
                break;
            case TunePowerName.Singularity:
                TunePower = "Singularity";
                break;
            case TunePowerName.Galactic:
                TunePower = "Galactic";
                break;
            default:
                break;
        }
    }
}
