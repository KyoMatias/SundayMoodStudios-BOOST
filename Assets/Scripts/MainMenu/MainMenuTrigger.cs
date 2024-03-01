using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTrigger : MonoBehaviour
{   
    public delegate void Seq();
    public static event Seq OnSequenceDone;

    public bool IsClickable;

    void OnEnable()

    {
        OnSequenceDone += StartMenu;
    }

    void OnDisable()
    {
        OnSequenceDone -= StartMenu;
    }

    void Awake()
    {
        IsClickable = false;
    }

    public void StartMenu()
    {
        IsClickable = true;
        OnSequenceDone?.Invoke();
    }

}
