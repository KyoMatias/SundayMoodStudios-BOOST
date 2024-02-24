using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class DebugController : MonoBehaviour
{
        bool showConsole;
        string input;

        public static DebugCommand gm_race;
        public static DebugCommand gm_debug;

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
    gm_race = new DebugCommand("race", "Switches GameMode To Race.", "race", () =>
    {
        ModeMaster.Instance.RaceModeActive();
    });

    gm_debug = new DebugCommand("debug", "Switches to a debug camera instance that allows the player to freely move around in space", "debug", () =>
    {
        ModeMaster.Instance.DebugCamActive();
    });


    // ui_toggle = new DebugCommand<int>("ui.camera", "Sets the DebugUI cameras to Active/Inactive", "ui_toggle <value>", (x) => 
    // {
    //      = x;
    // });

    commandList = new List<object>
    {
        gm_race,
        gm_debug,
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
