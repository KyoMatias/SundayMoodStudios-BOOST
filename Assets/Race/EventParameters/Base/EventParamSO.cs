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
        Max,
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
    [SerializeField] private int MinValue;
    [SerializeField] private int SecValue;
    [SerializeField] private float MillValue;
    public string CourseTime;
    [SerializeField] private float Length;
    public string CourseLength;
    [SerializeField] private int EventID;
    public Sprite Banner;
    public RivalStats Rival;
    
    [Header("Rival Stats")]
    public string RivalName;

    public string RivalCar;
    public string RivalTunePower;

    private void OnEnable()
    {
        DisplayEventType();
        FetchRivalStats();
        CalculateTime();
        PrintLength();
        GetCourseTime();
        GetCourseLength();
    }

    public int GetEventID()
    {
        return EventID;
    }

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

    public string GetCourseTime()
    {
        return CourseTime;
    }

    public string GetCourseLength()
    {
        return CourseLength;
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
            case EventType.Max:
                TypeDisplay = "Maximum Trial";
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

     void FetchRivalStats()
    {
        RivalName = Rival.R_Name;
        RivalCar = Rival.Car;
        RivalTunePower = Rival.TunePower;
    }

    void CalculateTime()
    {
        CourseTime = MinValue + ":" + SecValue + ":" + MillValue;
    }

    void PrintLength()
    {
        CourseLength = Length + " KM";
    }
    
    
    
}
