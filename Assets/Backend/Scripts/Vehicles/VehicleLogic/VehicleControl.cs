using System.Collections;
using System.Collections.Generic;
using CarControls;
using UnityEngine;

public class VehicleControl : MonoBehaviour
{
    [SerializeField] private WCAssign _WCA;
    [SerializeField] private PlayerController playerController;
    public GameObject PlayerVehicleGO;
    public GameObject PlayerVehicle;
    private Rigidbody rb ;
    public float CarSpeed;
    void Awake() {
        PlayerVehicleGO = GameObject.FindGameObjectWithTag("Player");
        PlayerVehicle = GameObject.FindGameObjectWithTag("ActiveVehicle");
        _WCA = GetComponent<WCAssign>();
        playerController = PlayerVehicleGO.GetComponentInParent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerController.CarSpeed = rb.velocity.magnitude * 3.6f;
            float movingDirection = Vector3.Dot(transform.forward, rb.velocity);
            playerController.Slip = Vector3.Angle(transform.forward, rb.velocity-transform.forward);
            if (movingDirection < -0.5f && playerController.Gas > 0)
            {
                playerController.Brake = Mathf.Abs(playerController.Gas);
            }
            else if (movingDirection > 0.5f && playerController.Gas < 0)
            {
                playerController.Brake = Mathf.Abs(playerController.Gas);
            }
            else
            {
                playerController.Brake = 0;
            }
    }

    public void ApplyThrottle()
       {
             if(PlayerController.CurrentDriveType == PlayerController.Drivetype.RearWheel)
            {
                 _WCA.Player_WheelsCollider.RL.motorTorque = playerController.Gas * playerController.HorsePower *  10f;
                 _WCA.Player_WheelsCollider.RR.motorTorque = playerController.Gas * playerController.HorsePower * 10f;
                
        }
             else if (PlayerController.CurrentDriveType == PlayerController.Drivetype.FrontWheel)
             {
                 _WCA.Player_WheelsCollider.FL.motorTorque = playerController.Gas;
                 _WCA.Player_WheelsCollider.FR.motorTorque = playerController.Gas;
             }
             else if (PlayerController.CurrentDriveType == PlayerController.Drivetype.AllWheel)
             {
                 _WCA.Player_WheelsCollider.RL.motorTorque = playerController.Gas;
                 _WCA.Player_WheelsCollider.RR.motorTorque = playerController.Gas;
                 _WCA.Player_WheelsCollider.FL.motorTorque = playerController.Gas;
                 _WCA.Player_WheelsCollider.FR.motorTorque = playerController.Gas;
             }

         }

    public void ApplySteering()
        {
            float steeringAngle = playerController.Steer * playerController.steerMultiplier;
        //playerController.Steer * playerController.steerMultiplier  * playerController.SteerCurve.Evaluate(CarSpeed);
        _WCA.Player_WheelsCollider.FL.steerAngle = steeringAngle;
            _WCA.Player_WheelsCollider.FR.steerAngle = steeringAngle;
        }

    public void ApplyBrake()
    {
        float brakeValue = playerController.Brake * playerController.BrakeValue;
        
        PlayerVehicle.GetComponent<Rigidbody>().AddForce(0, 0, -20f, ForceMode.Force);
        _WCA.Player_WheelsCollider.FL.brakeTorque = brakeValue;
        _WCA.Player_WheelsCollider.FR.brakeTorque = brakeValue;
        _WCA.Player_WheelsCollider.RR.brakeTorque = brakeValue;
        _WCA.Player_WheelsCollider.FL.brakeTorque = brakeValue;
        
    }
}
