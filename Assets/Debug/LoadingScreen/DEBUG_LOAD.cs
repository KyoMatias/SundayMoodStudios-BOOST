using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DEBUG_LOAD : MonoBehaviour
{
    private AssetBundle SceneBundle;
    [SerializeField]private string[] paths;

    private void Start() {

        StartCoroutine(InLoadDelay(5));
    }


    IEnumerator InLoadDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("WORLD",LoadSceneMode.Additive);
        yield return new WaitForSeconds(2);
        SceneManager.UnloadSceneAsync("LoadingScreen");
    }
}
