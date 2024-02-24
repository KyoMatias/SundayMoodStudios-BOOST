using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ModeMaster : MonoBehaviour
{
    /*
        [ModeMaster Log]
        {This script, named "ModeMaster," is a centralized manager for different game modes in a Unity game. 
        It is a singleton class, meaning there is only ever one instance of it in the game. 
        The purpose of this script is to provide a simple and accessible way to change between different game modes, such as "RaceMode," "FreeMode," and "DebugCam."}
    */

    //Creates a singleton Instance of the class in order for any other scripts to call the ModeMaster Instance and modify its parameters to its liking.
    public static ModeMaster Instance {get; private set;} 

     public static GameMode CallGameMode; // DEBUG: Testing variable to be called to other scripts (This is currently used in the HUD Paremeters)


    //Safety Net for the instance variable.
    void Awake()
    {
        if(Instance != null && Instance != this)//Catches if the instance is a duplicate, and destroys it if it is a duplicate.
        {
            Destroy(this);
        }

        else 
        {
            Instance = this;//permamently sets the instance to this script.
        }
    }


    /*
        GameMode Enums Hold the value and the name for each mode, (can be modified to add or remove modes. Do adjust modifications by adding a case in the ChangeGamemode(GMVal) function.)
    */
    public enum GameMode
    {
        /*Summary: 
            RaceMode is a progressional mode, player starts from the beginning of the race and is required to finish the race via the end of the course.
            RaceMode's Parameters has 3 stages, 
                Intro - Has the Opening Cinematic NIS [Non Interactable Sequence] that showcase an entrance to the race, Also engages a Countdown sequence then this will be disabled once race starts.
                RaceMain - Activates player controls, progression and HUD.
                End - Checks playerposition, racestatus and displays end hud.

        */
        RaceMode = 0, 
        FreeMode = 1,

        DebugCam = 2,

        /*Legend
            NIS = Non Interactable Sequence.
                NIS has 3 Options
                RandNIS = Picks a random NIS Sequence from a pool and initializes it for the current race opening.
                FixedNIS = Sets a constant NIS Sequence to the current race (Used for uneven geometry/space/compatabilty)
                BossNIS = Sets a Constant NIS With special Openings, this NIS also stores the value for an Opponent Vehicle to which the player will race.
        
        */
    }
    
   

    public void ChangeMode(int GMVal) // The main Function that controls the Gamemode cases. Needs to pass an integer to execute the funtion
    {
        GameMode currentMode = (GameMode)GMVal; //Fetches the Integer that will be used to value the switch case below
        CallGameMode = currentMode;

        switch(currentMode)
        {
            case GameMode.RaceMode:
            break;

            case GameMode.FreeMode:

            break;

            case GameMode.DebugCam:
            break;

            default:
            break;
        }
    }

    /*
    
    [Public variables]
     These are functions that were implicitly made public in order for the instace to access them and change whenever needed.
    */
    public void DefaultMode() 
    {
        ChangeMode(1);
    }

    public void RaceModeActive()
    {
        ChangeMode(0);
    }

    public void FreeModeActive()
    {
        ChangeMode(1);
    }

    public void DebugCamActive()
    {
        ChangeMode(2);
    }


}
