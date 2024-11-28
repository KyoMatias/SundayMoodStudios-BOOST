using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum P_TunePowerName
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

[CreateAssetMenu(fileName = "PlayerComponent", menuName = "Player")]
public class PlayerStats : ScriptableObject
{
    public string P_Name;
    [TextArea]
    public string P_Description;
    public string P_Clan;
    public string P_Car;
    public int P_CarHP;
    public int P_CarUpgradeLvl;
    public char P_CarRank;
    public string P_TunePower;
    public P_TunePowerName TunePowerType;

    private void OnEnable()
    {
        CalculateTunePower();
    }

    private void CalculateTunePower()
    {
        switch (TunePowerType)
        {
                case P_TunePowerName.Aster:
                    P_TunePower = "Aster";
                    break;
                case P_TunePowerName.Meteor:
                    P_TunePower = "Meteor";
                    break;
                case P_TunePowerName.Comet:
                    P_TunePower = "Comet";
                    break;
                case P_TunePowerName.Nebula:
                    P_TunePower = "Nebula";
                    break;
                case P_TunePowerName.Pulsar:
                    P_TunePower = "Pulsar";
                    break;
                case P_TunePowerName.Quasar:
                    P_TunePower = "Quasar";
                    break;
                case P_TunePowerName.Supernova:
                    P_TunePower = "Supernova";
                    break;
                case P_TunePowerName.Horizon:
                    P_TunePower = "Horizon";
                    break;
                case P_TunePowerName.Singularity:
                    P_TunePower = "Singularity";
                    break;
                case P_TunePowerName.Galactic:
                    P_TunePower = "Galactic";
                    break;
                default:
                    break;
        }
    }
}

