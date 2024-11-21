using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CarController : MonoBehaviour
{
    //[Boolean is used as a Catch Parameter to Differentiate between NIS and Ingame Physics]
    public bool CarEngine;
    public bool Burnout;
    public bool IsSequenced;
    public bool IsControlled;
    public float Gas;
    public float Brake;
    public float Steer;
    public float HP;
    public float BHP;
    public float slip;
    private float speed;
    public static CarState carState;
    public float steerMultiplier;
    public AnimationCurve SteerCurve;

    //[Paramters for Car Physics]
    private Rigidbody rb;
    public WheelMeshes _wheelMeshes;
    public WheelColliders _wheelCollider;

    [SerializeField] private string carname;
    // Start is called before the first frame update

    [System.Serializable]
    public class WheelMeshes 
    {
        public MeshRenderer FLm;
        public MeshRenderer FRm;
        public MeshRenderer BLm;
        public MeshRenderer BRm;
    }
    [System.Serializable]
    public class WheelColliders
    {
        public WheelCollider FL;
        public WheelCollider FR;
        public WheelCollider BL;
        public WheelCollider BR;
    }


    public enum CarState
    {
        VehicleOff,
        VehicleOn,
        Cutscene,
        Sequence,
        Burnout,
        Race,
        Finish
    }
    void Awake()
    {

    }

    void Start()
    {
        IsSequenced = true;
        CheckUserControl();
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        speed = rb.velocity.magnitude;
        GetWheelPosition();
        Cinematic();
        CheckUserControl();
    }

    void Cinematic()
    {
        if (IsSequenced)
        {
            
        }
    }

    public void CheckUserControl()
    {
        if(CarEngine)
        {
            CheckInput();
            ApplyGas();
            ApplySteering();
        }

        BurnoutParameters();
        //This Is a net to check if the user is allowed control of the vehicle physics (this is due to the model either in a cutscene)
    }

    public void BurnoutParameters()
    {        
        if(Burnout)
        {
            _wheelCollider.FR.brakeTorque = Mathf.Infinity;
            _wheelCollider.FL.brakeTorque = Mathf.Infinity;
        }
        else
        {
            _wheelCollider.FR.brakeTorque = 0;
            _wheelCollider.FL.brakeTorque = 0;
        }
    }

    public void ControllerOveride()
    {
        
    }
    public void CheckInput()
    {
        Gas = Input.GetAxis("Vertical");
        Steer = Input.GetAxis("Horizontal");
        float movingDirection = Vector3.Dot(transform.forward, rb.velocity);
        slip = Vector3.Angle(transform.forward, rb.velocity-transform.forward);
        if (movingDirection < -0.5f && Gas > 0)
        {
            Brake = Mathf.Abs(Gas);
        }
        else if (movingDirection > 0.5f && Gas < 0)
        {
            Brake = Mathf.Abs(Gas);
        }
        else
        {
            Brake = 0;
        }
    }

     public void ApplyBrake()
    {
        _wheelCollider.FR.brakeTorque = Brake * BHP * 0.7f;
        _wheelCollider.FL.brakeTorque = Brake * BHP * 0.7f;

        _wheelCollider.BR.brakeTorque = Brake * BHP * 0.3f;
        _wheelCollider.BR.brakeTorque = Brake * BHP * 0.3f;
    }


    public void ApplyGas()
    {
        _wheelCollider.BR.motorTorque = HP * Gas;
        _wheelCollider.BL.motorTorque = HP * Gas;
    }

      public void ApplySteering()
    {
        float steeringAngle = Steer * steerMultiplier * SteerCurve.Evaluate(speed);
        _wheelCollider.FR.steerAngle = steeringAngle;
        _wheelCollider.FL.steerAngle = steeringAngle;
    }

     public void GetWheelPosition()
    {
        UpdateWheels(_wheelCollider.FR, _wheelMeshes.FRm);
        UpdateWheels(_wheelCollider.FL, _wheelMeshes.FLm);
        UpdateWheels(_wheelCollider.BR, _wheelMeshes.BRm);
        UpdateWheels(_wheelCollider.BL, _wheelMeshes.BLm);
    }
    public void UpdateWheels(WheelCollider col, MeshRenderer wheelMesh)
    {
        Quaternion rot;
        Vector3 position;
        col.GetWorldPose(out position, out rot);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = rot;
    }


    public void CarStateModifier(CarState state)
    {
        CarState CurrentState = state; 
        carState = CurrentState;
        

        switch(CurrentState)
        {
            case CarState.VehicleOff:
            CarEngine = false;
            break;

            case CarState.VehicleOn:
            CarEngine = true;
            break;

            case CarState.Cutscene:
            break;

            case CarState.Sequence:
            break;

            case CarState.Burnout:
            Burnout = true;
            CarEngine = true;
            break;

            case CarState.Race:
            CarEngine = true;
            Burnout = false;
            ModeMaster.Instance.RaceModeActive();
            break;

            case CarState.Finish:
            break;
            default:
            break;
        }
    }

    public void StateOff()
    {
        CarStateModifier(CarState.VehicleOff);
    }
    public void StateOn()
    {
        CarStateModifier(CarState.VehicleOn);
    }
    public void StateSeq()
    {
        CarStateModifier(CarState.Sequence);
    }
    public void StateCutscene()
    {
        CarStateModifier(CarState.Cutscene);
    }
    public void StateBurnout()
    {
        CarStateModifier(CarState.Burnout);
    }
    public void StateRace()
    {
        CarStateModifier(CarState.Race);
    }
    public void StateFinish()
    {
        CarStateModifier(CarState.Finish);
    }
}