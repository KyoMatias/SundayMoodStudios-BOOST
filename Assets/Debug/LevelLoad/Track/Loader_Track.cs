using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Loader_Track : MonoBehaviour
{
    [SerializeField] private LevelLoad _load;
    


    private void OnEnable()      
    {
        Debug.Log("PreLevel Phase");
        StartCoroutine(LoadDelay(2));
    }

    public void LoadMap()
    {
        Debug.Log("Map Loaded!");
        _load.Map = Instantiate(_load.MapAsset());
    }

    public void LoadCars()
    {
        Debug.Log("Cars Loaded!");
        _load.Player_Car = Instantiate(_load.Player_CarAsset());
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
        LoadEventStat();
        LoadMap();
        LoadCars();
        
    }


}
