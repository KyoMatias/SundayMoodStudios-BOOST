using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class OverallManager : MonoBehaviour
{
    #region 
    //Manager Instantiate Code.
    private static OverallManager _instance;
    public static OverallManager Instance
    {
        get
        {
            if(_instance == null)
            
                Debug.LogError("Manager Is Null / Not Found");

                return _instance;
        }
    }
    void Awake()
    {
        _instance = this;
    }

    #endregion
    [SerializeField] private string buildversion;

    public enum GameState
    {
        Splash_Screen,
        OP_Disclaimer,
        Intro,
        Intro_Standby,
        Main_Menu,
        Loading_Screen,
        Race_Sequence,
        Race_Countdown,
        Race_Active,
    }
    public static GameState activeState;

    public string BuildVersion()
    {
        return buildversion;
    }

    public GameState StateStatus()
    {
        return activeState;
    }

    public void CurrentStateModifier(GameState state)
    {
        GameState CurrentState = state;
        activeState = CurrentState;

        switch(CurrentState)
        {
            case GameState.Splash_Screen:
            break;
            case GameState.OP_Disclaimer:
            break;
            case GameState.Intro:
            break;
            case GameState.Intro_Standby:
            break;
            case GameState.Main_Menu:
            break;
            case GameState.Loading_Screen:
            break;
            case GameState.Race_Sequence:
            break;
            case GameState.Race_Countdown:
            break;
            case GameState.Race_Active:
            break;
            default:
            break;
        }
    }


    public void StateSplash()
    {
        CurrentStateModifier(GameState.Splash_Screen);   
    }
    public void StateDisclaimer()
    {
        CurrentStateModifier(GameState.OP_Disclaimer);
    }
    public void StateIntro()
    {
        CurrentStateModifier(GameState.Intro);
    }

    public void StateStandby()
    {
        CurrentStateModifier(GameState.Intro_Standby);   
    }
    
    public void StateMenu()
    {
        CurrentStateModifier(GameState.Main_Menu);
    }

    public void StateLoading()
    {
        CurrentStateModifier(GameState.Loading_Screen);
    }

    public void StateRaceSeq()
    {
        CurrentStateModifier(GameState.Race_Sequence);
    }

    public void StateRaceCD()
    {
        CurrentStateModifier(GameState.Race_Countdown);
    }

    public void StateRaceLive()
    {
        CurrentStateModifier(GameState.Race_Active);
    }





}
