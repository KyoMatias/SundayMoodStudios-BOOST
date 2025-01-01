using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BOOST_Manager : MonoBehaviour
{
    [Header("Managers")]
    public static BOOST_Manager instance;
    public GameManager gameManager;
    public KeyManager keyManager;



    [Header("Game Parameters")]
    public PlayStatus GameStatus;
    public StoryStatus Story;
    public MasterKey MasterKey;

    /*
     These paramenters are considered static from the initialization phase,
    All variables are required in order for a PlayerProfile to be created.
    The game will rely on these variables ona medium scale and creates a potential 
    to create multiple player profiles in future development.
     */

    [Header("Player Parameters")] 
    [SerializeField] private string playerName; //Player name is the player's actual name (to be prompted during registration or invitation)
    [SerializeField] private string Username; // The Username is the player's in-game name, to be used on main menu's and event records.
    [SerializeField] private bool playerAccountRegisteredStatus;// [TBA Featured] To ensure the game is properly licensed and official. (to prevent piracy and ensure the player is either given permission)
    public StoryCharacter CurrentCharacter;// Determines the Story Chapter's current character selected by the player 






    public enum StoryCharacter // shows the cureent story character selected for the profile showcase.
    {
        FreePlayer,
        Hitomi_Nakazato,
        Ken_Sakamoto,
        Nica_Murasaki,
        Yuzuki_Tsuchiya,
        Rinoa_Ahn,
    }




    [Header("States and Settings:")]
    [SerializeField] private string gameVersion;
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

    [Serializable]
    public class BOOST_Developer
    {
        public string Build;
        public string GameVersion;
        public bool Registered;
        public string RegistrationID;
        public bool DeveloperMode;
        public bool DeveloperModeEnabled;
        public MasterKey Key;

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

        GetRegistrationID(DeveloperProperties);
        CheckRegistration(DeveloperProperties, MasterKey);

        FetchScripts();

    }


    private void FetchScripts()
    {
        keyManager = GetComponent<KeyManager>();
        gameManager = GetComponent<GameManager>();
    }

    public void GetRegistrationID(BOOST_Developer Developer)
    {
        string RegID = Developer.Key.MasterValue;
        SetRegistrationID(RegID);
    }

    public void SetRegistrationID(string ID)
    {
        if (keyManager.CurrentID == null)
        {
            Debug.Log("No valid keys are in the database");
        }
        else
        {
            Debug.Log($"Key is registered as : CURRENT [{keyManager.CurrentID}]: in the keyManager");
            keyManager.CurrentID = ID;
        }
    }


    // This fucntion takes in the paramters of the Developer and Masterkey Variables and Checks if the Values Match.
    public void CheckRegistration(BOOST_Developer Developer, MasterKey masterKey)
    {
        Debug.Log(masterKey.MasterValue);//Prints in Console the actual value.
        Debug.Log(Developer.Key.MasterValue);//Prints in the Console the actual value.

        /*
         * Main Checker Function (NEEDS TO BE UPDATED TO WORK WITH A PIRACY SCRIPT)
         * Check if interface methods are viable for creating the network scripts. 
         * To ensure the copies/playtesting are valid from developer.
         * 
         * 1. Needs more Elaboration and try to use tasks.
         * 2. Develop a better system for numerous keys.
         * 3. Create a series of master keys to be implemented as official keys.
         * 
         */




        /*
         * Steps for better key checker:
         * 
         * 1. for loop 
         */
    }

    public bool RegisterGame(bool parms, BOOST_Developer Developer)
    {
        return Developer.Registered = parms;
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
