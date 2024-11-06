using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAudioStack : MonoBehaviour
{
    public EngineAudio[] engineNotes;
    public float rpm;
    public float masterVolume;

    static float[] workingVolumes = new float[3]; // or maximum number of engine notes you need

    private Engine engine;

    private void Awake() {
        engine = GetComponent<Engine>();
    }

    private void Update()
    {

        rpm = engine.roundedValue;
        // The total volume calculated for all engine notes won't generally sum to 1.
        // Calculate what they do sum to and then scale the individual volumes to ensure
        // consistent volume across the RPM range.
        float totalVolume = 0f;
        for(int i = 0; i < engineNotes.Length; ++i)
        {
            totalVolume += workingVolumes[i] = engineNotes[i].SetPitchAndGetVolumeForRPM(rpm);
        }

        if (totalVolume > 0f)
        {
            for (int i = 0; i < engineNotes.Length; ++i)
            {
                engineNotes[i].SetVolume(masterVolume * workingVolumes[i] / totalVolume);
            }
        }
    }
}