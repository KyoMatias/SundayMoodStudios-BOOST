using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GearManager : MonoBehaviour
{

    [SerializeField] private bool HasPlayedGear;
    [SerializeField] private Animator GearHUI;
    [SerializeField] private TextMeshProUGUI GearUI;

    private void Awake() {
        GearHUI = gameObject.GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GearsLogic.Instance.GearPlus += ShiftUpAnimation;
        HasPlayedGear = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeNumber();
    }

    void ChangeNumber()
    {
        GearUI.SetText(GearsLogic.Instance.CurrentGear.ToString());
        //GearUI.text = GearsLogic.Instance.CurrentGear.ToString();
    }

    private IEnumerator PlayShiftAnimation()
    {
            GearHUI.SetTrigger("ShingUp");
            yield return new WaitForSeconds(0.5f);
            GearHUI.ResetTrigger("ShingUp");
    }
    
    void ShiftUpAnimation()
    {
        StartCoroutine(PlayShiftAnimation());
    }


}
