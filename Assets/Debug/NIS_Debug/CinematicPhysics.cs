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
        public MeshRenderer FRLm;
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



    private void FixedUpdate()
    {
        GetWheelPosition();
    }


    public void GetWheelPosition()
    {
        _wheelMeshes.RRm.transform.Rotate(0,0,0, Space.World);
    }
}
