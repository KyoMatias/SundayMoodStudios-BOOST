using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    private static CarSpawner _instance;
    public static CarSpawner Instance
    {
        get
        {
            if(_instance == null)

            Debug.LogError("CarSpawner Not Engaged!");
            return _instance;
        }
    }

    [SerializeField]private GameObject playerCar;
    private void Awake() {
        _instance = this;
        playerCar = Resources.Load<GameObject>("Vehicles/NICAFD/PLAY_RX7FD_(STORY_NICA)");

    }

    private void Start() {
        FindPlayerVehicle();
    }

    private void 
        Update() {
        
    }

    void FindPlayerVehicle()
    {
        SpawnPlayerCar();
        playerCar = GameObject.FindGameObjectWithTag("ActiveVehicle");
        Debug.Log("Finding Car");
        if(playerCar != null)
        {
            Debug.Log("CarFound");
        }
        
        else
        {
            SpawnPlayerCar();
        }
    }

    private void SpawnPlayerCar()
    {
        Instantiate(playerCar, transform.position, quaternion.identity);
    }
    
}
