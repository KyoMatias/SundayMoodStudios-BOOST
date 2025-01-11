using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public int ScreenCount;
    public GameObject[] Screens;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplaySelectedScreen(ScreenCount);
    }

    void DisplaySelectedScreen(int index)
    {
        if(gameObject == null || Screens.Length == 0)
        {
            Debug.LogError("No screens found");
            return;
        }

        if(index < 0 || index >= Screens.Length)
        {
            Debug.LogError("Invalid screen index (Out of range)");
            return ;
        }

        for(int i = 0; i < Screens.Length; i++)
        {
            if(Screens[i] != null)
            {
                Screens[i].SetActive(i == index);
            }
        }
    }
}
