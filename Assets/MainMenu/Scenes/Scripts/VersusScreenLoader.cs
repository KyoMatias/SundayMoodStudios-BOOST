using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VersusScreenLoader : MonoBehaviour
{
    
    LoadingScreenManager loadingScreenManager;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreenManager = GetComponent<LoadingScreenManager>();
        loadingScreenManager.OnLoadFinished += LoadScene;
    }

    void LoadScene()
    {
        StartCoroutine(WaitForScene(1));
        SceneManager.LoadScene("VersusScreen", LoadSceneMode.Additive);
        Debug.Log("Scene Is Loaded");
    }


    IEnumerator WaitForScene(float time)
    {
        yield return new WaitForSeconds(time);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
