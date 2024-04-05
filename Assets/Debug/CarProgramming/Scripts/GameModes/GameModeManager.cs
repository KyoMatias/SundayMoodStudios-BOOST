using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{

    public enum GameStates
    {
        SplashScreen,
        OP_Intro,
        Garage_MainMenu,
        Garage_Race,
        Garage_Options,
        Garage_Exit,
    }
    public static GameModeManager Instance {get; private set;}

    public event Action OnEngage;   
    public event Action OnResetCD;

    private ModeMaster m_modemaster
    {
       get{ return FindObjectOfType<ModeMaster>();}
    }
    
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else 
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);

        m_modemaster.OnCountdownActivate += StartCountdown;
        
    }


    void StartCountdown(bool val)
    {
        if(val)
        {
            OnEngage?.Invoke();
            Debug.Log("CountdownStarted");
        }
        else if(!val)
        {
            OnResetCD?.Invoke();
            Debug.Log("Countdown Reset");
        }
    }
}
