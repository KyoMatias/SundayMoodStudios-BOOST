using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
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


    public void InitLoadingScreen(float loadTime)
    {
        StartCoroutine(LoadingScreenTimer(loadTime));
    }
    IEnumerator LoadingScreenTimer(float time)
    {
        yield return new WaitForSeconds(time);
        bool IsSet = false;

        if (!IsSet)
        {
            SceneManager.LoadScene("LoadingScreen_General", LoadSceneMode.Single);
            IsSet = true;
        }
    }
}

