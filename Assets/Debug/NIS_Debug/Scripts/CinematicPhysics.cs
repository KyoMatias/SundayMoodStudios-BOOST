using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using static CarController;

public class CinematicPhysics : MonoBehaviour
{

    [SerializeField] private enum CinematicState
    {
        Stationary,
        FreeWheel,
        Lock,
        Neutral,
    }

    [SerializeField] private CinematicState CineState;
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


    [Range(-1f, 1f)]
    public float SteerAnimations;

    private float Steer;
    public float steerMultiplier;
    public AnimationCurve SteerCurve;



    private void Awake() {

    }

    public void FixedUpdate()
    {
        GetWheelPosition();
        CinePhysics_UpdateState();
        ApplySteer();
        

    }


    private void CinePhysics_UpdateState()
    {
        switch(CineState)
        {
            case CinematicState.Stationary:
            StateStationary();
            break;
            case CinematicState.FreeWheel:
            StateFreewheel();
            break;
            default:
            break;
        }
    }


    public void StateFreewheel()
    {
        _wheelCollider.BL.motorTorque = 0.0001f;
        _wheelCollider.BR.motorTorque = 0.0001f;
        _wheelCollider.FL.motorTorque = 0.0001f;
        _wheelCollider.FR.motorTorque = 0.0001f;
    }

    public void StateStationary()
    {
        _wheelCollider.BL.motorTorque = 0f;
        _wheelCollider.BR.motorTorque = 0f;
        _wheelCollider.FL.motorTorque = 0f;
        _wheelCollider.FR.motorTorque = 0f;
    }


     public void GetWheelPosition()
    {
        UpdateWheels(_wheelCollider.FR, _wheelMeshes.FRm);
        UpdateWheels(_wheelCollider.FL, _wheelMeshes.FLm);
        UpdateWheels(_wheelCollider.BR, _wheelMeshes.RRm);
        UpdateWheels(_wheelCollider.BL, _wheelMeshes.RLm);
    }
    public void UpdateWheels(WheelCollider col, MeshRenderer wheelMesh)
    {
        Quaternion rot;
        Vector3 position;
        col.GetWorldPose(out position, out rot);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = rot;
    }

    public void ApplySteer()
    {
        Steer = SteerAnimations;
        float steeringAngle = Steer * steerMultiplier;
        _wheelCollider.FR.steerAngle = steeringAngle;
        _wheelCollider.FL.steerAngle = steeringAngle;
    }
}
