using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{

    // Start is called before the first frame update

    public delegate void StateSignals();
    public static StateSignals onFreeClicked;

    public delegate void Transitions();
    public static Transitions OnMenuToFreePlay;
    public static Transitions OnFreeToMenu;

    private Animator m_animator;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    void OnMouseEnter()
    {
        {
            {
                m_animator.SetTrigger("OnHover");
            }
        }
    }
    
    void OnMouseExit() 
    {
        {
            m_animator.SetTrigger("OutHover");

        }
    }

    public void OnMouseDown() 
    {
        onFreeClicked.Invoke();
        OnMenuToFreePlay.Invoke();
         Debug.Log("Button Engaged");
    }
    
}


