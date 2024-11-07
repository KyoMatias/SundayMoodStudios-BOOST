using System;
using System.Collections;
using System.Collections.Generic;
using CarControls;
using UnityEngine;

public class GearsLogic : MonoBehaviour
{
    private static GearsLogic _instance;
    public static GearsLogic Instance { get; private set; }
    public enum GearCount
    {
        R = -1,
        N = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Fifth = 5,
        Sixth = 6,
    }

    [SerializeField] private GearCount gear;
    private int sprocket = 1;
    private int gearlvl;

    public int CurrentGear;

    public event Action GearPlus;
    public event Action GearMinus;
    // Start is called before the first frame update
    private void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        } 
        else{
            Instance = this;
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GearCheck();
    }


    private void GearSetting(int gear)
    {
        GearCount currentGearCount = (GearCount) gear;
        switch (currentGearCount)
        {
            case GearCount.R:
            break;
            case GearCount.N:
            break;
            case GearCount.First:
            break;
            case GearCount.Second:
            break;
            case GearCount.Third:
            break;
            case GearCount.Fourth:
            break;
            case GearCount.Fifth:
            break;
            case GearCount.Sixth:
            break;
            default:
            break;
        }
    }

    private void GearCheck()
    {
        
    }


    public void GearShiftUp()
    {
        GearPlus?.Invoke();
        GearChangeMaster(sprocket);
        Debug.Log("Upshift");
    }

    public void GearShiftDown()
    {
        GearMinus?.Invoke();
        GearChangeMaster(-sprocket);
        Debug.Log("Downshift");
    }
    void GearChangeMaster(int value)
    {
            gearlvl += value;

            CurrentGear = gearlvl;

            if(gearlvl < 0)
            {
                gearlvl = 0;
            }
    }

}
