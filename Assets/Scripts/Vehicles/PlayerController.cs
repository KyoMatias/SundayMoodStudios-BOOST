 using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    public enum TransmissionSettings
    {
        Automatic,
        Manual,
        TrueManual,
    }   
    public enum Drivetype
    {
    [Header("DriveType")]
        RearWheel,
        FrontWheel,
        AllWheel,
        FourWheel,
    }

    public enum DriveMode
    {
        [Header("DriveMode")]
        EngineOff,
        EngineOn,
        Cutscene,
        Sequenced,
        Burnout,
        Race,
        Finish
    }


    [Header("Private Settings")]
    [SerializeField] private TransmissionSettings currentTransmission;
    [SerializeField] private DriveMode currentDriveMode;
    [SerializeField] private Drivetype currentDriveType;
    [SerializeField] private CarStat currentCarStat;

    public enum Gear
    {
    [Header("Gear")]
    Reverse = -1,
    Neutral = 0,
    First = 1,
    Second = 2,
    Third = 3,
    Fourth = 4,
    Fifth = 5,
    Sixth = 6,
    Seventh = 7,


    }


    [Header("Vehicle Overlook")]
    [SerializeField] private Gear currentGear;
    public float Gas;
    public float Brake;
    public float Steer;
    [SerializeField] private float horsePower;
    [SerializeField] private float brakeHorsepower;
    [SerializeField] private float slip;
     public float CarSpeed = 0;
    [SerializeField] private float engineRPM;
    public float steerMultiplier;
    public AnimationCurve SteerCurve;
    public string vehicleName {get ; private set;}

    

    
    [System.Serializable]
    public class WheelMesh
    {
        [Header("Wheel Meshes")]
        public MeshRenderer FrontLeftMesh;
        public MeshRenderer FrontRightMesh;
        public MeshRenderer RearLeftMesh;
        public MeshRenderer RearRightMesh;
    }

    [System.Serializable]

    public class WheelCollisions
    {
        [Header("Wheel Colliders")]
        public WheelCollider FL;
        public WheelCollider FR;
        public WheelCollider RL;
        public WheelCollider RR;
    } 
    

    private Rigidbody rb ;
    public WheelMesh C_WheelMeshes;
    public WheelCollisions C_WheelCollisions;


    private void Awake() {
        
    }

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    public void FixedUpdate() {
        CarSpeed = rb.velocity.magnitude;
        InputController();
        WheelPosition();
        ApplyThrottle();
        ApplySteering();
        GearSwitch();
    }

    public void InputController()
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

        CarSpeed = rb.velocity.magnitude * 3.6f;
    }
    public float EnginePhysics()
    {
        engineRPM = currentCarStat.IdleRPM + (Gas * (currentCarStat.IdleRPM * horsePower));
        return engineRPM;
    }

    
    private void ApplyThrottle()
    {
        horsePower = currentCarStat.HP / 0.20f;
        EnginePhysics();
        if(currentDriveType == Drivetype.RearWheel)
        {
            C_WheelCollisions.RR.motorTorque = horsePower * Gas;
            C_WheelCollisions.RL.motorTorque = horsePower * Gas;

        }
        else if (currentDriveType == Drivetype.FrontWheel)
        {
            C_WheelCollisions.FR.motorTorque = horsePower * Gas;
            C_WheelCollisions.FL.motorTorque = horsePower * Gas;
        }
        else if (currentDriveType == Drivetype.AllWheel)
        {
            C_WheelCollisions.RR.motorTorque = horsePower * Gas;
            C_WheelCollisions.RL.motorTorque = horsePower * Gas;
            C_WheelCollisions.FR.motorTorque = horsePower * Gas;
            C_WheelCollisions.FL.motorTorque = horsePower * Gas;
        }
    }

    public void ApplySteering()
    {
        float steeringAngle = Steer * steerMultiplier * SteerCurve.Evaluate(CarSpeed);
        C_WheelCollisions.FR.steerAngle = steeringAngle;
        C_WheelCollisions.FL.steerAngle = steeringAngle;
    }

    public void GearSwitch()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentGear += 1;
        }
        
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            currentGear -= 1;
        }
    }
    
    

    public void WheelPosition()
    {
        WheelUpdate(C_WheelCollisions.FR, C_WheelMeshes.FrontRightMesh);
        WheelUpdate(C_WheelCollisions.FL, C_WheelMeshes.FrontLeftMesh);
        WheelUpdate(C_WheelCollisions.RR, C_WheelMeshes.RearRightMesh);
        WheelUpdate(C_WheelCollisions.RL, C_WheelMeshes.RearLeftMesh);
    }
    public void WheelUpdate(WheelCollider collider, MeshRenderer wheelMeshRender)
    {
        Quaternion rot;
        Vector3 position;
        collider.GetWorldPose(out position, out rot);
        wheelMeshRender.transform.position = position;
        wheelMeshRender.transform.rotation = rot;
    }




}


