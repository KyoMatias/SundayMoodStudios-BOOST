using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarControls;

namespace AIDriver
{
    public class AI_CarController : MonoBehaviour
    {
        public PlayerController ControllerParent;
        private void Awake()
        {
            ControllerParent = GetComponent<PlayerController>();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
