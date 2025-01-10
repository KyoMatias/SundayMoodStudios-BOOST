using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Debug/PartSO", fileName = "Project/Debug/Part")]
public class PartSO : ScriptableObject
{
    public string Name;
    public bool EquipedStatus;
    public Material[] BaseColors;
    public string Manufacturer;
    public Sprite ManufacturerLogo;


    private void OnEnable()
    {
        
    }

    void SetParameters()
    {
        
    }
    
    
}
