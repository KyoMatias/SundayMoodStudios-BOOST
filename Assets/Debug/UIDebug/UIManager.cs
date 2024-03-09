using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
        public GameObject UI_Camera;
        public GameObject UI_Gamemode;
        public GameObject UI_Takeover;
    
    [Header("Camera Overlays")]
    public bool Cameras;

    [Header("Debug Data")]
    public bool GameMode;

    [Header("Takeover")]
    public bool Takeover;


    public static UIManager Instance {  get; private set; }


    void Awake()
    {
        Cameras = false;
        GameMode = false;
        Takeover = false;

        if (Instance != null && Instance != this)//Catches if the instance is a duplicate, and destroys it if it is a duplicate.
        {
            Destroy(this);
        }

        else
        {
            Instance = this;//permamently sets the instance to this script.
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCamera();
        CheckOverlay();
        CheckData();
    }

    public void CheckCamera()
    {
        if(Cameras)
        {
            UI_Camera.SetActive(true);
        }
        else 
        {
            UI_Camera.SetActive(false);
        }
    }

    public void CheckData()
    {
        if(GameMode)
        {
            UI_Gamemode.SetActive(true);
        }
        else 
        {
            UI_Gamemode.SetActive(false);
        }
    }

    public void CheckOverlay()
    {
        if(Takeover)
        {
            UI_Takeover.SetActive(true);
        }
        else{
            UI_Takeover.SetActive(false);
        }
    }


    public bool ToggleTakeover(bool value)
    {
        Takeover = value;
        return Takeover;
    }


    public void GMChecker()
    {
        //Create a switch case for this
    }
}
