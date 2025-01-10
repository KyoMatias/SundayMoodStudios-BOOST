using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLockToParent : MonoBehaviour
{
    public GameObject CarGO;

    private void Awake()
    {
        CarGO = GameObject.FindGameObjectWithTag("ActiveVehicle");
    }






    // Update is called once per frame
    void FixedUpdate()
    {
        ConnectPlayerCar();
    }
    

    

    void ConnectPlayerCar()
    {
        transform.SetParent(CarGO.transform);
    }
}
