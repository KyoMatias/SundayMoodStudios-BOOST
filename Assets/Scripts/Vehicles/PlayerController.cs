using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

namespace CarControls
{
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
        public static Drivetype CurrentDriveType;
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

        [Header("Script Fetcher")]
        public InputReciever inputReciever;



        [Header("Vehicle Overlook")]
        [SerializeField] private Gear currentGear;
        public float Gas;
        public float Brake;
        public float Steer;
        public float HorsePower;
        public float BrakeValue;
        public float Slip;
         public float CarSpeed = 0;
        [SerializeField] private float engineRPM;
        public float steerMultiplier;
        public AnimationCurve SteerCurve;
        public string vehicleName {get ; private set;}


        private GearsLogic _gearsLogic;


        private void Awake() {
            _gearsLogic = GetComponentInChildren<GearsLogic>();
        }

        private void Start() {
            
        }



        public void Update() {
            
            InputController();
            GasPedal();
            BrakePedal();
            Steering();
            Shifter();
            // WheelPosition();
            // ApplyThrottle();
            // ApplySteering();
            // GearSwitch();
        }


    void Shifter()
    {
        ShiftUp();
        ShiftDown();

    }
    public void ShiftUp()
    {
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _gearsLogic.GearShiftUp();
            //Deb.Log("Gear Status: UP ");
        }
    }
    public void  ShiftDown()
    {
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            _gearsLogic.GearShiftDown();
            Debug.Log("Gear Status: DOWN ");
        }
    }
        public void InputController()
        {
            Gas = Input.GetAxis("Vertical");
            Steer = Input.GetAxis("Horizontal");         
        }
        public float EnginePhysics()
        {
            engineRPM = currentCarStat.IdleRPM + (Gas * (currentCarStat.IdleRPM * HorsePower));
            return engineRPM;
        }

        private void AttachToInputReciever()
        {

        }

        public void GasPedal()
        {
            InputReciever.Instance.RecieveGas();
        }

        public void BrakePedal()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InputReciever.Instance.RecieveBrake();
            }
        }
        public void Steering()
        {
            InputReciever.Instance.RecieveSteering();
        }


        /*private void ApplyThrottle()
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
        */
    }
}


