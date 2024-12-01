using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public float GasValue ;
    public Debug_WheelMeshes ColliderValue;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Gas();
    }

    void Gas()
    {
        GasValue = Input.GetAxis("Vertical");
        ColliderValue.wheelColliders.WCBL.motorTorque = GasValue * 400f;
        ColliderValue.wheelColliders.WCBR.motorTorque = GasValue * 400f;
    }
}
