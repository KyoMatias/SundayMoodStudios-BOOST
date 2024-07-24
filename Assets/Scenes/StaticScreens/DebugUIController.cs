using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text BuildVersion;
    [SerializeField] private TMP_Text DebugState;
    private string debugstate;
    
    // Start is called before the first frame update
    void Start()
    {
        string build = OverallManager.Instance.BuildVersion();
        BuildVersion.text = build;
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
    }

    private void CheckState()
    {
       DebugState.text = OverallManager.activeState.ToString(debugstate);
    }
}
