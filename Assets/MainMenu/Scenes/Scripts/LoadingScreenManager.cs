using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{

    public float TemporaryWaitingTime = 5;
    public event Action OnLoadFinished;
    public bool IsSceneLoad;

    [Header("UI Elements")] [SerializeField]
    private GameObject FadePanel;
    private Animator FadePanelAnimator;
    [SerializeField]private GameObject MainUI;



    [SerializeField] private bool FadeI;

    [SerializeField] private bool FadeO;

    // Start is called before the first frame update

    private void Awake()
    {
        IsSceneLoad = false;
    }

    void Start()
    {

        FadePanel = GameObject.FindGameObjectWithTag("FadeUI");
        FadePanelAnimator = FadePanel.GetComponent<Animator>();
        FadeIn();
    }

    private void Update()
    {
        TemporaryWaitingTime -= Time.deltaTime;
        if (TemporaryWaitingTime <= 0)
        {
            TemporaryWaitingTime = 0;
            FadeOut();
            StartCoroutine(LoadVersus(1));
        }
    }

    IEnumerator LoadVersus(float time)
    {
        yield return new WaitForSeconds(time);
        if (!IsSceneLoad)
        {
            OnLoadFinished?.Invoke();
            MainUI.SetActive(false);
            IsSceneLoad = true;
        }
    }

    void FadeIn()
    {
        if (!FadeI)
        {
            FadePanelAnimator.SetTrigger("Fin");
        }
    }


    void FadeOut()
    {
        if (!FadeO)
        {
            FadePanelAnimator.SetTrigger("Fout");
            FadeO = true;
        }
    }


    IEnumerator TimerMain(float time)
    {
        yield return new WaitForSeconds(time);
    }
    
}

