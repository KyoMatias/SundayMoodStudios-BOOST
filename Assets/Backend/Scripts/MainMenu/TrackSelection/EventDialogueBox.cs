using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventDialogueBox : MonoBehaviour
{
    [SerializeField] private TrackManager trackManager;
    
    public TextMeshProUGUI Default_EventString;

    public TextMeshProUGUI Default_MapString;

    public TextMeshProUGUI Player_StringName;
    public TextMeshProUGUI Player_Car;
    public TextMeshProUGUI Player_TunePower;
    public TextMeshProUGUI Opponent_StringName;
    public TextMeshProUGUI Opponent_Car;
    public TextMeshProUGUI Opponent_TunePower;

    public TextMeshProUGUI RaceType;
    public TextMeshProUGUI RaceLength;
    public TextMeshProUGUI RaceTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        
        Default_EventString.SetText("Event: " + trackManager.D_EventString);
        Default_MapString.SetText("Map: " + trackManager.D_MapString);
        Player_StringName.SetText("Player: " + trackManager.P_StringName);
        Player_Car.SetText("Car: " + trackManager.P_Car);
        Player_TunePower.SetText("Tune Power: " + trackManager.P_TunePower);
        Opponent_StringName.SetText("Rival: " + trackManager.O_StringName);
        Opponent_Car.SetText("Car: " + trackManager.O_Car);
        Opponent_TunePower.SetText("Tune Power: " + trackManager.D_TunePower);
        RaceType.SetText("Race Type: " + trackManager.D_RaceCat);
        RaceLength.SetText("Race Length: " + trackManager.D_RaceLen);
        RaceTime.SetText("Race Time: " + trackManager.D_RaceTime);
        
        
    }
}
