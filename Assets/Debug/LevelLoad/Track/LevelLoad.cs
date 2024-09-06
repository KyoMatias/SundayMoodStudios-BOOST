using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "TrackData", menuName = "Track")]
public class LevelLoad : ScriptableObject
{
    public GameObject Map;
    public GameObject Player_Car;

    [Header("Player Car Position")]
    public float P_X;
    public float P_Y;
    public float P_Z;

    [Header("Player Car Rotation")]

    public float R_X;
    public float R_Y;
    public float R_Z;


    public GameObject MapAsset()
    {
        return Map;
    }

    public GameObject Player_CarAsset()
    {
        Player_Car.transform.position = new Vector3(P_X,P_Y,P_Z);
        Player_Car.transform.Rotate(R_X,R_Y,R_Z);
        return Player_Car;
    }



    
    

}
