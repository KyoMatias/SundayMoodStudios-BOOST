using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public static TrackManager Instance;
    
    [Header("Current Track Selection")]
    public string D_EventString;
    public string D_MapString;

    public string O_StringName;

    public string O_Car;

    public string D_TunePower;

    public string D_RaceCat;

    public string D_RaceLen;

    public string D_RaceTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
