using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayVariables : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI GM;
    [SerializeField] private TextMeshProUGUI CS;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        GM.text = ModeMaster.Instance.CallGameMode.ToString(); 
        CS.text = CarController.carState.ToString();
    }

}
