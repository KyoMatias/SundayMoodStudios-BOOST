using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParentGO : MonoBehaviour
{

    public GameObject EmptiesPV;
    // Start is called before the first frame update
    void Start()
    {
        EmptiesPV = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EmptiesPV.transform.position = this.transform.position;
    }
}
