using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_AI_Controller : MonoBehaviour
{
    public float AI_Gas;
    public WheelMeshes _wheelMeshes;
    public WheelColliders _wheelCollider;
    [System.Serializable]

    public class WheelMeshes
    {
        public MeshRenderer FLm;
        public MeshRenderer FRm;
        public MeshRenderer RLm;
        public MeshRenderer RRm;
    }

    [System.Serializable ]
    public class WheelColliders
    {
        public WheelCollider FL;
        public WheelCollider FR;
        public WheelCollider BL;
        public WheelCollider BR;
    }

    public enum RaceStart 
    {
        Burnout,
        Go,
    }

    public RaceStart State;

    public CarStat carstat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SignalCar()
    {
        switch(State)
        {
            case RaceStart.Burnout:
            break;
            case RaceStart.Go:
            Gas();
            break;
            default:
            break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        SignalCar();
    }

    public void Gas()
    {
        float HP = carstat.HP;
        _wheelCollider.BL.motorTorque = HP * AI_Gas;
        _wheelCollider.BR.motorTorque = HP * AI_Gas;
    }

    public void AI_Burnout()
    {
        float HP = carstat.HP;
        _wheelCollider.BL.motorTorque = HP * AI_Gas;
        _wheelCollider.BR.motorTorque = HP * AI_Gas;
        _wheelCollider.FR.motorTorque = 0;
        _wheelCollider.FL.motorTorque = 0;
    }
    









}
