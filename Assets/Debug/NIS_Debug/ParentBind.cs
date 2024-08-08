using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParentBind : MonoBehaviour
{
    public float MoveSpeed = 1.0f;
    [SerializeField] private GameObject Animation_CarParent;

    private Transform parentTrans;
    // Start is called before the first frame update
     

    
    void Awake()
    {
        parentTrans = Animation_CarParent.transform;
    }
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        WheelSpin();
    }


    public void WheelSpin()
    {
        var step = MoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, parentTrans.position, step);

        if(Vector3.Distance(transform.position, parentTrans.position) < 0.001f)
        {
            parentTrans.position *= -1.0f;
        }

    }
}
