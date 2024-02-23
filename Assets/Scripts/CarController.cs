using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //[Boolean is used as a Catch Parameter to Differentiate between NIS and Ingame Physics]
    public bool IsSequenced;
    public bool IsControlled;

    public float Gas;
    public float Brake;
    public float Steer;
    public float HP;
    public float BHP;
    public float slip;
    private float speed;
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



    void Start()
    {
        IsSequenced = true;
        CheckUserControl();
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        CheckInput();
        GetWheelPosition();
        ApplyGas();
    }

    public void CheckUserControl()
    {
        //This Is a net to check if the user is allowed control of the vehicle physics (this is due to the model either in a cutscene)
    }

    public void ControllerOveride()
    {
        
    }
    public void CheckInput()
    {
        Gas = Input.GetAxis("Vertical");
        float movingDirection = Vector3.Dot(transform.forward, rb.velocity);
        
    }


    public void ApplyGas()
    {
        _wheelCollider.BR.motorTorque = HP * Gas;
        _wheelCollider.BL.motorTorque = HP * Gas;
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


}