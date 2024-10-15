using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BOOST_Manager : MonoBehaviour
{
    [Header("Game Parameters")]
    public PlayStatus GameStatus;
    public StoryStatus Story;
    public enum PlayStatus{
        Developer,
        Showcase,
        Alpha,
        Beta,
        Sample,
        Test,
        Debug,
        Play,
        PlayTest,
        Live
    }

    public enum StoryStatus
    {
        PreGame,
        FreePlay,
        Prologue,
        Chapter1,
        Chapter2,
        Chapter3,
        Chapter4,
        Chapter5,
        Chapter6,
        Chapter7,

    }

    public static BOOST_Manager instance;
    [Serializable]
    public class BOOST_Developer
    {
        public string Build;
        

    }

    public BOOST_Developer DeveloperProperties;


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
    public GameState activeState;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public string BuildVersion()
    {
        return DeveloperProperties.Build;
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
