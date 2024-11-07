using CarControls;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI SpeedMeter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpeedMeter.SetText(playerController.CarSpeed.ToString("#"));
    }
}
