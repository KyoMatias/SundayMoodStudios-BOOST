using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using NaughtyAttributes;

public class VectorCarControl : MonoBehaviour
{
    [SerializeField] private float initialVelocity;
    [SerializeField] private float finalVelocity;
    [SerializeField] private float accelarationMaxSeconds;
    private Rigidbody rb;
    private bool flag;
    private float timer;

    [SerializeField] private float GasTest;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        flag = false;

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = rb.velocity.magnitude;
        FlagChecker();
    }

    private void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20), $"{speed}");// DRAWGUI: SPEED
    }

    void FlagChecker()
    {
            GasTest = Input.GetAxis("Vertical");
            timer += Time.deltaTime;// Time Variable
            Debug.Log(timer / accelarationMaxSeconds);//Print to Console
            rb.velocity = Vector3.Lerp(new Vector3(0,0,initialVelocity),new Vector3(0,0,  finalVelocity * GasTest ), timer / accelarationMaxSeconds);
            //Master VectorLerp, Responsible for vehicle test acceleration.


    }
        // Inspector Panel Tests.
        [Button]
        public void StartVelocityTravel()
        {
            rb.AddForce(new Vector3(0, 0,finalVelocity * GasTest));
        }
        [Button]
        public void EndVelocityTravel()
        {
            flag = false;
        }
}
