using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string MapName;
    
    
    // Start is called before the first frame update
    void Start()
    {
        loadMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadMap()
    {
        SceneManager.LoadScene(MapName, LoadSceneMode.Single);
    }
}
