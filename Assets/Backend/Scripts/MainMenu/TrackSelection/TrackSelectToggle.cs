using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSelectToggle : MonoBehaviour
{

    public Toggle TrackToggle;
    public EventParamSO EventParameters;
    private TrackManager TManager;

    public event Action<bool> OnToggle;

    public int EventIDToggle;
    private void Awake()
    {
        OnToggle?.Invoke(false);
        TManager = FindObjectOfType<TrackManager>();
        EventIDToggle = EventParameters.GetEventID();
    }

    private void Update()
    {
        
    }

    public void SendEvent(bool value)
    /*
     * Checks what EventID is currently active and
     * sends the data to the selected graphic.
     * Tracks the selected data and if confirmed
     * will select the current track as main.
     */
    {
        if (value)
        {
            UpdateStatsToManager();
            Debug.Log(EventParameters.GetEventID());
        }
    }
    
    void UpdateStatsToManager() 
    // Sends all data to Canvas, All Parameters are checked and evaluated.
    {
        TManager.D_EventString = EventParameters.GetEventName();
        TManager.D_MapString = EventParameters.GetCourse();
        TManager.P_StringName = EventParameters.PlayerName;
        TManager.P_Car = EventParameters.PlayerCar;
        TManager.P_TunePower = EventParameters.PlayerTunePower;
        TManager.O_StringName = EventParameters.RivalName;
        TManager.O_Car = EventParameters.RivalCar;
        TManager.D_TunePower = EventParameters.RivalTunePower;
        TManager.D_RaceCat = EventParameters.GetTypeDisplay();
        TManager.D_RaceLen = EventParameters.GetCourseLength();
        TManager.D_RaceTime = EventParameters.GetCourseTime();
    }
    
}
