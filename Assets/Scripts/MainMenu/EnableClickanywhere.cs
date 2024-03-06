using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableClickanywhere : MonoBehaviour
{
    [SerializeField] private GameObject m_scripts;

    // Start is called before the first frame update
    void Start()
    {
        m_scripts.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ClickAnywhere()
    {
         m_scripts.SetActive(true);
    }
}
