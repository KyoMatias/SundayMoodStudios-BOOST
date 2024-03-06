using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance {get; private set;}
    
    MainMenuTrigger triggerEvent;

    private bool StartGame;


    
    
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        StartGame = false;
    }

    void Update()
    {

    }

    public bool UpdateMainMenuToClickAnywhere(bool value)
    {
        StartGame = value;
        return StartGame;
    }
}
