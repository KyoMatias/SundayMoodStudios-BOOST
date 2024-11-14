using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReciever : MonoBehaviour
{

    private static InputReciever _instance;
    public static InputReciever Instance
    {
        get
        {
            if (_instance == null)
            Debug.LogError("Input Reciever Not Connected! Check Parent GO");
            return _instance;
        }
    }

    private MotorFunctions motorFunctions;
    private void Awake()
    {
    _instance = this;
     motorFunctions = GetComponent<MotorFunctions>();
    }
        


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveGas()
    {
        motorFunctions.ApplyThrottle();
    }

    public void RecieveSteering()
    {
        motorFunctions.ApplySteering();
            
    }

    public void RecieveBrake()
    {
        motorFunctions.ApplyBrake();
    }
}
