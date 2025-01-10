using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_UI : MonoBehaviour
{
    private bool OnDev;
    public BOOST_Manager BoostManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnDev = BOOST_Manager.instance.DrawDebugUI;
    }

    void ActivateDEBUG()
    {
        if (OnDev)
        {
            GUIStyle defaultStyle = new GUIStyle();
            defaultStyle.fontSize = 30;
            defaultStyle.normal.textColor = Color.white;

            // Style for the Race State value
            GUIStyle stateStyle = new GUIStyle();
            stateStyle.fontSize = 30;
            stateStyle.normal.textColor = Color.yellow;
            GUI.Label(new Rect(10, 10, 120, 100), "Environment: ", defaultStyle);
            // Draw the current state in yellow
            GUI.Label(new Rect(200, 10, 180, 100), BoostManager.GameStatus.ToString(), stateStyle);
            GUI.Label(new Rect(10, 10, 120, 100), "\nMenu State: ", defaultStyle);
            GUI.Label(new Rect(300, 10, 180, 100), BoostManager.activeState.ToString(), stateStyle);
        }
    }

    void OnGUI()
    {
        ActivateDEBUG();
    }
}
