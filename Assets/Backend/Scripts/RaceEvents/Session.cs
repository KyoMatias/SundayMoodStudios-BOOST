using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[System.Serializable]
public class Status
{
    public enum State
    {
        Init,
        OPCS,
        BSeq,
        RCount,
        RActive,
        RInter,
        RPause,
        REnd,
        RSum,
    }

    [SerializeField]  // Ensures visibility in Inspector
    private State currentRaceState;

    public State CurrentRaceState
    {
        get => currentRaceState;
        private set
        {
            currentRaceState = value;
            Debug.LogWarning("Race State swapped to: " + currentRaceState);
        }
    }

    public void ChangeState(State newState)
    {
        CurrentRaceState = newState;
    }
}
   

public class Session : MonoBehaviour
{
    
    public Status raceStatus;
    // Start is called before the first frame update
    void Start()
    {
        raceStatus = new Status();
        raceStatus.ChangeState(Status.State.Init);
    }

    async void Awake()
    {
        await InitRaceStatus();
        Debug.Log("Done INIT");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(raceStatus);
        if (Input.GetKeyDown(KeyCode.P))
        {
            raceStatus.ChangeState(Status.State.RActive);
        }
    }
    

    public void SetRace(Status status)
    {
        status.ChangeState(status.CurrentRaceState);
    }

    async Task InitRaceStatus()
    {
        Debug.Log("Initializing Race State");
        await Task.Delay(3000);
        SetRace(raceStatus);
        await Task.Delay(1000);
        Debug.Log("Race State Initialized");
        await Task.Yield();
    }


    void OnGUI()
    {
        // Vector2 nativeSize = new Vector2(1280, 960);
        // Vector3 scale = new Vector3 (Screen.width / nativeSize.x, Screen.height / nativeSize.y, 1.0f);
        // GUI.matrix = Matrix4x4.TRS (new Vector3(0, 0, 0), Quaternion.identity, scale);
        // GUI.Label(new Rect(10, 10, 300, 100), "Race State: " + raceStatus.CurrentRaceState);
        // Default style for the label
        GUIStyle defaultStyle = new GUIStyle();
        defaultStyle.fontSize = 30;
        defaultStyle.normal.textColor = Color.white;

        // Style for the Race State value
        GUIStyle stateStyle = new GUIStyle();
        stateStyle.fontSize = 30;
        stateStyle.normal.textColor = Color.yellow;

        // Draw "Race State:" in white
        GUI.Label(new Rect(10, 10, 120, 100), "Race State: ", defaultStyle);

        // Draw the current state in yellow
        GUI.Label(new Rect(120, 10, 180, 100), raceStatus.CurrentRaceState.ToString(), stateStyle);
    }

}
