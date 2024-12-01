using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Debug_WheelMeshes : MonoBehaviour
{
    [System.Serializable]
    public class WheelMesh
    {
        [Header("Get Generic ")] 
        public MeshRenderer FL;
        public MeshRenderer FR;
        public MeshRenderer BL;
        public MeshRenderer BR;
    }

    [System.Serializable]
    public class WheelColliders
    {
        [Header("Get Wheel Collider")]
        public WheelCollider WCFL;
        public WheelCollider WCFR;
        public WheelCollider WCBL;
        public WheelCollider WCBR;
    }
    
    public WheelMesh wheelMeshes;
    public WheelColliders wheelColliders;

    void FixedUpdate()
    {
        WheelPosition();
    }

    void WheelPosition()
    {
        WheelUpdate(wheelColliders.WCFL, wheelMeshes.FL);
        WheelUpdate(wheelColliders.WCFR, wheelMeshes.FR);
        WheelUpdate(wheelColliders.WCBL, wheelMeshes.BL);
        WheelUpdate(wheelColliders.WCBR, wheelMeshes.BR);
    }

    public void WheelUpdate(WheelCollider col, MeshRenderer mes)
    {
        Quaternion rot;
        Vector3 pos;
        
        col.GetWorldPose(out pos, out rot);
        
        mes.transform.rotation = rot;
        mes.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
