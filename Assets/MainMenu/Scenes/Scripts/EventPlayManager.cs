using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayManager : MonoBehaviour
{
    [SerializeField] private EventParamSO eventParameter;
    [SerializeField] private string eventName;
    [SerializeField] private string eventCourse;
    [SerializeField] private string eventTypeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        DisplayStats();   
    }

    void DisplayStats()
    {
        eventName = eventParameter.GetEventName();
        eventCourse = eventParameter.GetCourse();
        eventParameter.DisplayEventType();
        eventTypeDisplay = eventParameter.GetTypeDisplay();
    }
}
