using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

   public void LoadScene()
   {
      SceneManager.LoadScene("NIS_DEB", LoadSceneMode.Additive);
   }
}
