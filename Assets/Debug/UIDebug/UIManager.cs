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


    void Awake()
    {
        Cameras = false;
        GameMode = false;
        Takeover = false;
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

    void CheckCamera()
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

    void CheckData()
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

    void CheckOverlay()
    {
        if(Takeover)
        {
            UI_Takeover.SetActive(true);
        }
        else{
            UI_Takeover.SetActive(false);
        }
    }

    // public void InitCamera(GameObject cam)
    // {
    //     Ui
    // }
}
