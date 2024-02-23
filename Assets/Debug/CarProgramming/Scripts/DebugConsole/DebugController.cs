using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DebugController : MonoBehaviour
{
        bool showConsole;
        string input;

        public static DebugCommand gm_race;

        public List<object> commandList;

public void OnConsole()
{
    showConsole = !showConsole;
}


private void Awake()
{
    gm_race = new DebugCommand("RaceMode", "Switches GameMode To Race.", "gm_race", () =>
    {
        ModeMaster.Instance.RaceModeActive();
    });
}

private void OnGUI()
{
    if(!showConsole) {return;}

    float y = 0f;

    GUI.Box(new Rect(0, y ,Screen.width, 30), "");
    GUI.backgroundColor = new Color(51, 36, 66, 0.5f);
    input = GUI.TextField(new Rect(10f, y + 5f, Screen.width -20f, 20f), input);

}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Slash))
        {
            OnConsole();
        }
    }
}
