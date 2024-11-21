using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTrigger : MonoBehaviour
{
    LoadScene _sceneloader;

/*
    private void OnEnable()
    {
        _sceneloader.OnSceneLoad += TriggerLoad;
    }

    private void OnDisable()
    {
        _sceneloader.OnSceneLoad -= TriggerLoad;
    }
*/


    void TriggerLoad()
    {
        SceneManager.LoadScene("GarageMain");
    }
}
