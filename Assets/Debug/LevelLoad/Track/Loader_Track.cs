using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Loader_Track : MonoBehaviour
{
    [SerializeField] private LevelLoad _load;
    public string MapName;
    public string PlayerCarName;

    private void LoadPrefabs()
    {
        LoadEventStat();
        LoadMap();
        LoadCars();
    }
    


    private void OnEnable()      
    {
        Debug.Log("PreLevel Phase");
        StartCoroutine(LoadDelay(1));
        MapName = _load.Map;
        PlayerCarName = _load.Player_Car;
    }


    public void LoadMap()
    {
        GameObject mapPrefab = Resources.Load<GameObject>("Maps/" + MapName);

        if(mapPrefab != null)
        {
            Instantiate(mapPrefab, Vector3.zero , quaternion.identity);
            Debug.Log(mapPrefab + "Map Loaded!");
        }
        else
        {
            Debug.LogError("Load Failed");
        }
    }

    public void LoadCars()
    {
        Vector3 LoadCarPos = new Vector3(_load.P_X,_load.P_Y,_load.P_Z);
        GameObject CarPrefab = Resources.Load<GameObject>("Debug/Cars/" + PlayerCarName);


            if(CarPrefab != null)
            {
                Instantiate(CarPrefab, LoadCarPos, Quaternion.Euler(new Vector3(_load.R_X,_load.R_Y,_load.R_Z)));
                Debug.Log(CarPrefab + "Car Loaded!");
            }
            else
            {
                Debug.LogError("Car Load Failed");
            }

    }

    public void LoadEventStat()
    {
        Debug.Log("Stats Loaded!");
    }

    public void MainTickLoad()
    {
        StartCoroutine(LoadDelay(0));
    }

    IEnumerator LoadDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        LoadPrefabs();
        
    }


}
