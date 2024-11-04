using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Turbo : MonoBehaviour
{
public AudioSource Turbosource;
    public float minRPM;
    public float peakRPM;
    public float maxRPM;
    public float pitchReferenceRPM;

    public float SetPitchAndGetVolumeForRPM(float rpm)
    {
        Turbosource.pitch = rpm / pitchReferenceRPM;

        if (rpm < minRPM || rpm > maxRPM)
        {
            return 0f;
        }

        if (rpm < peakRPM)
        {
            return Mathf.InverseLerp(minRPM, peakRPM, rpm);
        }
        else
        {
            return Mathf.InverseLerp(maxRPM, peakRPM, rpm);
        }
    }

    public void SetVolume(float volume)
    {
        Turbosource.mute = (Turbosource.volume = volume) == 0;
    }

}
