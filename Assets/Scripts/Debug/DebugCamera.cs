using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCamera : MonoBehaviour
{

    public enum CameraModes
    {
        P = 0,
        D = 1,
    }


    public GameObject Racecamera;
    public GameObject Debugcamera;

    public delegate void Switcher();
    public static Switcher SwitchtoPlayer;
    public static Switcher SwitchtoDebug;



    private bool OnPlayer;
    private bool OnDebug;

    void Awake()
    {
        SwitchtoPlayer += SwitchCamP;
        SwitchtoDebug += SwitchCamD;
    }

    // Start is called before the first frame update
    void Start()
    {
        OnPlayer = true;
        OnDebug = false;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
    }


    private void CameraSwitcher(int value)
    {
        CameraModes currentMode = (CameraModes)value;

        switch(currentMode)
        {
            case CameraModes.P:
            OnPlayer = true;
            OnDebug = false;
            break;
            case CameraModes.D:
            OnPlayer = false;
            OnDebug = true;
            break;
            default:
            break;
        }
    }


    private void SwitchCamP()
    {
        CameraSwitcher(0);
    }

    private void SwitchCamD()
    {
        CameraSwitcher(1);
    }


    private void SwitchCamera()
    {
        if(OnPlayer)
        {
            Racecamera.SetActive(true);
            Debugcamera.SetActive(false);
        }

        else if(OnDebug)
        {
            Debugcamera.SetActive(true);
            Racecamera.SetActive(false);
        }
    }
}
