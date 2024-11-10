using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ANIMATIONS_MainMenu : MonoBehaviour
{
    private Animator m_CamAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        ButtonAnimation.OnMenuToFreePlay += MenuToFreeTransition;
        ButtonAnimation.OnFreeToMenu += FreeToMenuTransition;
        m_CamAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MenuToFreeTransition()
    {
        Debug.Log("Animation Triggered");
        m_CamAnimator.SetTrigger("Menu2Free");
        
        
    }

    void FreeToMenuTransition()
    {
        m_CamAnimator.SetTrigger("Free2Menu");
        }
}
