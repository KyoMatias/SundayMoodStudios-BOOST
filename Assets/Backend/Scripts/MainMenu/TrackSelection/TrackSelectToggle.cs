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
    {
        if (value)
        {
            UpdateStatsToManager();
            Debug.Log(EventParameters.GetEventID());
        }
    }
    void UpdateStatsToManager()
    {
        TManager.D_EventString = EventParameters.GetEventName();
        TManager.D_MapString = EventParameters.GetCourse();
        TManager.O_StringName = EventParameters.RivalName;
        TManager.O_Car = EventParameters.RivalCar;
        TManager.D_TunePower = EventParameters.RivalTunePower;
        TManager.D_RaceCat = EventParameters.GetTypeDisplay();
        TManager.D_RaceLen = EventParameters.GetCourseLength();
        TManager.D_RaceTime = EventParameters.GetCourseTime();
    }
    
}
