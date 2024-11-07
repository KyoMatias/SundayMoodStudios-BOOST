using System.Collections;
using System.Collections.Generic;
using CarControls;
using UnityEngine;

public class MotorFunctions : MonoBehaviour
{
    [SerializeField] private WheelColliderAssign wca;
    [SerializeField] private PlayerController playerController;
    public GameObject PlayerVehicleGO;
    private Rigidbody rb ;
    public float CarSpeed;
    void Awake() {
        PlayerVehicleGO = GameObject.FindGameObjectWithTag("Player");
        wca = GetComponent<WheelColliderAssign>();
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
                 wca.Player_WheelsCollider.RL.motorTorque = playerController.Gas *  100f;
                 wca.Player_WheelsCollider.RR.motorTorque = playerController.Gas *  100f;
             }
             else if (PlayerController.CurrentDriveType == PlayerController.Drivetype.FrontWheel)
             {
                 wca.Player_WheelsCollider.FL.motorTorque = playerController.Gas;
                 wca.Player_WheelsCollider.FR.motorTorque = playerController.Gas;
             }
             else if (PlayerController.CurrentDriveType == PlayerController.Drivetype.AllWheel)
             {
                 wca.Player_WheelsCollider.RL.motorTorque = playerController.Gas;
                 wca.Player_WheelsCollider.RR.motorTorque = playerController.Gas;
                 wca.Player_WheelsCollider.FL.motorTorque = playerController.Gas;
                 wca.Player_WheelsCollider.FR.motorTorque = playerController.Gas;
             }
         }

    public void ApplySteering()
        {
            float steeringAngle = playerController.Steer * playerController.steerMultiplier * playerController.SteerCurve.Evaluate(CarSpeed);
            //playerController.Steer * playerController.steerMultiplier * playerController.SteerCurve.Evaluate(CarSpeed);
            wca.Player_WheelsCollider.FL.steerAngle = steeringAngle;
            wca.Player_WheelsCollider.FR.steerAngle = steeringAngle;
        }
         
 }