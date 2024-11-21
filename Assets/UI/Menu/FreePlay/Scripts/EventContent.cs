using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class EventContent : MonoBehaviour
{
    [SerializeField] private EventParamSO EventPSO;

    [SerializeField] private TextMeshProUGUI EventTitle;
    [SerializeField] private TextMeshProUGUI CourseName;
    [SerializeField] private TextMeshProUGUI EventType;
    [SerializeField] private Image EventBanner;
    // Start is called before the first frame update
    void Update()
    {
        EventPSO.DisplayEventType();
        EventTitle.SetText(EventPSO.GetEventName());
        CourseName.SetText(EventPSO.GetCourse());
        EventType.SetText(EventPSO.GetTypeDisplay());
        EventBanner.overrideSprite = EventPSO.GetBanner();
        
    }
    
    
}
