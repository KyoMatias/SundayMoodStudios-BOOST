using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MasterKey", menuName = "Developer")]
public class MasterKey : ScriptableObject
{
    public string value1;
    public string value2;
    public string value3;
    private string dashval = "-";

    public string MasterValue;

    private void OnEnable()
    {
        MasterValue = value1 + dashval + value2 +dashval + value3;
    }
}
