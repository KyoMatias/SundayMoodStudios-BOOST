using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class MasterInputReceiver : MonoBehaviour
{
    
    private static MasterInputReceiver _instance;
    public static MasterInputReceiver Instance
       
    {
        get
        {
            if (_instance == null)
            Debug.LogError("Input Receiver Not Connected! Check Parent GO");
            return _instance;
        }
    }
    private VehicleControl _vehicleControl;
    private void Awake()
    {
    _instance = this;
       _vehicleControl = GetComponent<VehicleControl>();
    }

    public void RecieveGas()
    {
        _vehicleControl.ApplyThrottle();
    }

    public void RecieveSteering()
    {
        _vehicleControl.ApplySteering();
            
    }

    /*public void RecieveBrake()
    {
        _vehicleControl.ApplyBrake();
    }
    */
}
