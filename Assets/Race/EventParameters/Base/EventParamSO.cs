using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "EventParameter", menuName = "Event")]
public class EventParamSO : ScriptableObject
{
    public enum EventType
    {
        Free,
        Tutorial,
        Loop,
        Speed,
        Drift,
        Uphill,
        Downhill,
        Crew,
        Boss,
        Cinematic,
        Quest
    }
    
    [Header("Event Displays")]
    public string EventName;
    public string Course;
    [SerializeField] private EventType Type;
    private string TypeDisplay;
    [SerializeField] private int EventID;
    public Sprite Banner;
    



    public string GetEventName()
    {
        return EventName;
    }

    public string GetCourse()
    {
        return Course;
    }

    public string GetTypeDisplay()
    {
        return TypeDisplay;
    }
    public void DisplayEventType()
    {
        switch (Type)
        {
            case EventType.Free:
                TypeDisplay = "Open Drive";
                break;
            case EventType.Tutorial:
                TypeDisplay = "Tutorial";
                break;
            case EventType.Loop:
                TypeDisplay = "Orbital";
                break;
            case EventType.Speed:
                TypeDisplay = "Attack";
                break;
            case EventType.Drift:
                TypeDisplay = "Drift";
                break;
            case EventType.Uphill:
                TypeDisplay = "Ascend";
                break;
            case EventType.Downhill:
                TypeDisplay = "Descend";
                break;
            case EventType.Crew:
                TypeDisplay = "Swarm Pursuit";
                break;
            case EventType.Boss:
                TypeDisplay = "Duel Pursuit";
                break;
            case EventType.Cinematic:
                TypeDisplay = "Story Chapter";
                break;
            case EventType.Quest:
                TypeDisplay = "Expedition";
                break;
        }
    }

    public Sprite GetBanner()
    {
        return Banner;
    }
    
    
    
}
