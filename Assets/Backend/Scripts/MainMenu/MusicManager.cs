using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
    [Header("Background Soundtracks")] 
    [SerializeField] private AudioSource VersusBGM;
    [SerializeField] private AudioSource MainMenuBGM;

    
    
    public enum MusicState
    {
        Default = 0,
        MainMenu = 1,
        Selection = 2,
        Versus = 3,
        Ingame = 4,
    }
    [SerializeField] private MusicState musicState;
    
    
    // Start is called before the first frame update
    void Start()
    {
        STATE_MainMenu.Instance.OnMainMenu += SwitchMainMenu;
        STATE_MainMenu.Instance.OnVersus += SwitchVersus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeMusicState(int newState)
    {
        musicState = (MusicState)newState;
        switch (musicState)
        {
            case MusicState.MainMenu:
                MainMenuBGM.Play();
                VersusBGM.Stop();
                break;
            case MusicState.Versus:
                VersusBGM.Play();
                MainMenuBGM.Stop();
                break;
            case MusicState.Ingame:
                
                break;
            case MusicState.Selection:
                
                break;
            default:
                break;
            
        }
    }

    void SwitchMainMenu()
    {
        ChangeMusicState(1);
    }
    void SwitchVersus()
    {
        ChangeMusicState(3);
    }
}
