using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointContainer : MonoBehaviour
{

    public List<Transform> waypoints;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Transform tr in gameObject.GetComponentInChildren<Transform>())
        {
            waypoints.Add(tr);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
