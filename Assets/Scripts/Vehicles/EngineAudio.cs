using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EngineAudio : MonoBehaviour
{
  public AudioSource source;
    public float minRPM;
    public float peakRPM;
    public float maxRPM;
    public float pitchReferenceRPM;

    public float SetPitchAndGetVolumeForRPM(float rpm)
    {
        source.pitch = rpm / pitchReferenceRPM * 0.2f;

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
        source.mute = (source.volume = volume) == 0;
    }

}

