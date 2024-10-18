using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "TrackData", menuName = "Track")]
public class LevelLoad : ScriptableObject
{
    public string Map;
    public string Player_Car;

    [Header("Player Car Position")]
    public float P_X;
    public float P_Y;
    public float P_Z;

    [Header("Player Car Rotation")]

    public float R_X;
    public float R_Y;
    public float R_Z;


    public string MapAsset()
    {
        return Map;
    }
    
    public string PlayerCarAsset()
    {
        return Player_Car;
    }



    
    

}
