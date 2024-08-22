using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    private Animator m_animator;
    // Start is called before the first frame update
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

    void OnMouseDown() 
    {
         Debug.Log("FreePlay Engaged");
    }
    
}


