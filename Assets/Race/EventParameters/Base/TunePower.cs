using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunePower
{

    public string CurrentTunePowerName;
    public TunePowerName SwitchTunePowerName;

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
    
    
    private void CalculateTunePowerName()
    {
        switch (SwitchTunePowerName)
        {
            case TunePowerName.Aster:
                CurrentTunePowerName = "Aster";
                break;
            case TunePowerName.Meteor:
                CurrentTunePowerName = "Meteor";
                break;
            case TunePowerName.Comet:
                CurrentTunePowerName = "Comet";
                break;
            case TunePowerName.Nebula:
                CurrentTunePowerName = "Nebula";
                break;
            case TunePowerName.Pulsar:
                CurrentTunePowerName = "Pulsar";
                break;
            case TunePowerName.Quasar:
                CurrentTunePowerName = "Quasar";
                break;
            case TunePowerName.Supernova:
                CurrentTunePowerName = "Supernova";
                break;
            case TunePowerName.Horizon:
                CurrentTunePowerName = "Horizon";
                break;
            case TunePowerName.Singularity:
                CurrentTunePowerName = "Singularity";
                break;
            case TunePowerName.Galactic:
                CurrentTunePowerName = "Galactic";
                break;
            default:
                break;
        }
    }

}
