using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManger : MonoBehaviour
{
    public GameObject DEBUG_GAMEOBJECT;
    
    public Part[] partTypes;

    [SerializeField] private PartSO partSO;

    private void Awake()
    {
        //DEBUG_GAMEOBJECT = GameObject.FindGameObjectWithTag("Component");
        //partSO = DEBUG_GAMEOBJECT.GetComponent<PartSO>();
        //DEBUG: Fetch Parameters from Hierarchy. Get the basics to initialize GO implementation.
        
        
    }

    void Start()
    {
        SetAllParts();
    }

    public Part GetPartType(string partName)
    {
        for (int i = 0; i < partTypes.Length; i++)
        {
            if (partTypes[i].PartName == partName)
            {
                return partTypes[i];
            }
            
        }
        Debug.LogError("Body Cannot be loaded");
        return null;
    }
    
    public void SetPartFromID(Part partname, int number)
    {
        for (int i = 0; i < partname.VehicleBody.Length; i++)
        {
            foreach (GameObject gb in partname.VehicleBody[i].BodyPart) 
            {
                if (i == number)
                {
                    gb.SetActive(true);
                    partname.PartNumber = number;
                    partname.IsEquiped = true;
                }

                else
                {
                    gb.SetActive(false);
                }
            }
        }
    }


    public void SetPartFromName(string partType, int select)
    {
        Part tempPart = GetPartType(partType);
        if (tempPart == null)
        {
            return;
        }
        tempPart.PartNumber = select;
        PlayerPrefs.SetInt("Parts1" + tempPart.PartName, select);
        for (int i = 0; i < tempPart.VehicleBody.Length; i++)
        {
            foreach (GameObject gb in tempPart.VehicleBody[i].BodyPart)
            {
                if (i == select)
                {
                    gb.SetActive(true);
                }
                else
                {
                    gb.SetActive(false);
                }
            }
        }
    }

    private void SetAllParts()
    {
        foreach (Part pt in partTypes)
        {
            int selectedItem = PlayerPrefs.GetInt("Parts1" + pt.PartName, 0);
            SetPartFromID(pt, selectedItem);
        }
    }

    [System.Serializable]
    public class Part
    {
        public string PartName;
        public int PartNumber;
        public Body[] VehicleBody;
        public bool IsEquiped;
        public enum PartManufacturer
        {
            Mazda,
            Nissan,
            Mitsubishi,
            Honda,
            Toyota
        }
    }

    [System.Serializable]
    public class Body
    {
        public GameObject[] BodyPart;
    }
    
    
    
    
}
