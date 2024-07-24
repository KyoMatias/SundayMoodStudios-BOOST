using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CarController;

public class CinematicPhysics : MonoBehaviour
{
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



    private void Awake() {

    }
    private void FixedUpdate()
    {
        GetWheelPosition();
        
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
}
