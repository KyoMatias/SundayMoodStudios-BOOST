using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class STATE_MainMenu : MonoBehaviour
{
    public static STATE_MainMenu Instance;
    public enum MenuStates
    {
        def,
        PanIn,
        MenuBanner_NORM,
        FREE_Clicked,
        FREE_Menu_Category,
        FREE_Cat_STANDARD,
        FREE_STANDARD_SETUP,
        FREE_STANDARD_SELECT,
        
    }


    [SerializeField] TextMeshProUGUI DEBUGHUD_STATE;

    public MenuStates CurrentState;
    private string Debug_Output;
    
    
    public event Action OnMainMenu;
    public event Action OnVersus;
    
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
        STATE_DEFAULT();
        ButtonAnimation.onFreeClicked += STATE_FREECLICKED;

    }
    private void Update() {
        
        Debug.Log("State: " + CurrentState);
        DEBUG_Display();

    }

    private void StateSwitcher(MenuStates state)
    {
        CurrentState = state;

        switch(CurrentState)
        {
            case MenuStates.def:
            Debug_Output = "null";
            break;
            case MenuStates.PanIn:
            Debug_Output = "Pan_In";
            OnMainMenu?.Invoke();   
            break;
            case MenuStates.MenuBanner_NORM:
            Debug_Output = "MenuBanner_NORM";
            break;
            case MenuStates.FREE_Clicked:
            OnVersus?.Invoke();    
            Debug_Output = "FREE_Clicked";
            break;
            case MenuStates.FREE_Menu_Category:
            break;
            case MenuStates.FREE_Cat_STANDARD:
            break;
            case MenuStates.FREE_STANDARD_SETUP:
            break;
            case MenuStates.FREE_STANDARD_SELECT:
            break;
            default:
            break;
        }
    }


    private void DEBUG_Display()
    {
        DEBUGHUD_STATE.text = Debug_Output;
    }


    public void STATE_DEFAULT()
    {
        StateSwitcher(MenuStates.def);
    }
    public void STATE_PanIN()
    {
        StateSwitcher(MenuStates.PanIn);
    }

    public void STATE_MENUBANNER()
    {
        StateSwitcher(MenuStates.MenuBanner_NORM);
    }

    public void STATE_FREECLICKED()
    {
        StateSwitcher(MenuStates.FREE_Clicked);
    }
}
