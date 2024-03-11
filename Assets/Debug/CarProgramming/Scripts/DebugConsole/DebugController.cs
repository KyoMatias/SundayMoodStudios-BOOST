using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DebugController : MonoBehaviour
{

    private CarController m_carcontroller
    {
        get{return FindAnyObjectByType<CarController>();}
    }
        bool showConsole;
        string input;

        public static DebugCommand gm_race;
        public static DebugCommand gm_debug;
        public static DebugCommand sw_RaceCam;
        public static DebugCommand sw_debugcam;
        public static DebugCommand ui_takeover1;
        public static DebugCommand ui_takeover0;
        public static DebugCommand gm_activatecd;

        public static DebugCommand cs_engineoff;
        public static DebugCommand cs_engineon;
        public static DebugCommand cs_burnout;
        public static DebugCommand cs_race;

        public static DebugCommand<int> ui_toggle;

        public List<object> commandList;

public void OnToggleDebug(InputValue value)
{
    showConsole = !showConsole;
}

public void OnReturn(InputValue value)
{
   if(showConsole)
    {
        HandleInput();
        input = "";
    }
}

private void Awake()
{
    //Beginning of Command Creation Parameters
    gm_race = new DebugCommand("gm race", "Switches GameMode To Race.", "race", () =>
    {
        ModeMaster.Instance.RaceModeActive();
    });

    gm_debug = new DebugCommand("gm debug", "Switches to a debug camera instance that allows the player to freely move around in space", "debug", () =>
    {
        ModeMaster.Instance.DebugCamActive();
    });

    sw_RaceCam = new DebugCommand("sw racecam", "Switches the Active Camera to a race cam instance","racecam", () =>
    {
        DebugCamera.SwitchtoPlayer?.Invoke();
    });
    
    sw_debugcam = new DebugCommand("sw debugcam", "Switches the active camera to a debug camera instance", "debugcam", ()=> 
    {
        DebugCamera.SwitchtoDebug?.Invoke();
    });

    ui_takeover1 = new DebugCommand("takeover 1", "adds takeover text", "takeover", () =>
        {
            UIManager.Instance.ToggleTakeover(true);
            UIManager.Instance.CheckCamera();
        });
    ui_takeover0 = new DebugCommand("takeover 0", "gets rid of the takeover text", "takeover", () =>
        {
            UIManager.Instance.ToggleTakeover(false);
        });
    gm_activatecd = new DebugCommand("gm resetcd", "starts a countdown sequence", "resetcd", () =>
    {
        ModeMaster.Instance.ActivateStartRace();
    });
    cs_engineoff = new DebugCommand("cs off","turns playercar engine off","cs engoff", ()=>
    {
        m_carcontroller.StateOff();
    });
    cs_engineon = new DebugCommand("cs on","turns playercar engine on","cs on", ()=>
    {
        m_carcontroller.StateOn();
    });
    cs_burnout = new DebugCommand("cs burnout","burnout mode","burnout", ()=>
    {
        m_carcontroller.StateBurnout();
    });
    cs_race = new DebugCommand("cs race","race mode","racemode", ()=>
    {
        m_carcontroller.StateRace();
    });




        //End of Command Creation Parameters
        commandList = new List<object>
    {
        gm_race,
        gm_debug,
        sw_RaceCam,
        sw_debugcam,
        ui_takeover0,
        ui_takeover1,
        gm_activatecd,
        cs_engineoff,
        cs_engineon,
        cs_burnout,
        cs_race

    };
}

private void OnGUI()
{
    if(!showConsole) {return;}

    float y = 0f;

    GUI.Box(new Rect(0, y ,Screen.width, 30), "");
    GUI.backgroundColor = new Color(51, 36, 66, 0.5f);
    input = GUI.TextField(new Rect(10f, y + 5f, Screen.width -20f, 20f), input);

}


void HandleInput()
{
    for(int i=0; i<commandList.Count; i++)
    {
        CommandBase commandBase = commandList[i] as CommandBase;
        if(input.Contains(commandBase.CommandID))
        {
            if(commandList[i] as DebugCommand != null)
            {
                (commandList[i] as DebugCommand).Invoke();
            }
        }
    }
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

//new DebugCommand("","","", ()=>{});