using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownSeq : MonoBehaviour
{
    [SerializeField] private GameObject countdownHud;

    private GameModeManager m_gmManager
    {
        get {return FindObjectOfType<GameModeManager>();}
    }

    
    public bool ActivatedCountdown;
    // Start is called before the first frame update
    void Start()
    {
         CheckCountdown(false);
    }

    void Awake()
    {
        countdownHud.SetActive(false);
        m_gmManager.OnEngage += ActiveCD;
    }


    // Update is called once per frame
    void Update()
    {
        if(ActivatedCountdown)
        {
            countdownHud.SetActive(true);
        }
        else 
        {
            CheckCountdown(false);
        }
    }

    public void ActiveCD()
    {
        CheckCountdown(true);
    }

    public void ResetCD()
    {
        CheckCountdown(false);
    }

    private bool CheckCountdown(bool val)
    {
        ActivatedCountdown = val;
        return ActivatedCountdown;
    }

}
