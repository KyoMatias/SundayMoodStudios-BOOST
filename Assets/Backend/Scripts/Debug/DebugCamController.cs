using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DebugCamController : MonoBehaviour
{
    public float Accel = 50;
    public float AccSprintMultiplier = 4;
    public float LookSens =1;
    public float Damping = 5;
    public bool FocusOnActive = true;

    Vector3 velocity;

    static bool Focused {
        get => Cursor.lockState == CursorLockMode.Locked;
        set{
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = value == false;
        }
    }

    void OnEnable()
    {
        if(FocusOnActive ) Focused = true;
    }

    void OnDisable() => Focused = false;

    void Update()
    {
        if(Focused)
            UpdateInput();
            else if(Input.GetMouseButtonDown(0))
            Focused = true;

            velocity = Vector3.Lerp(velocity, Vector3.zero, Damping* Time.deltaTime);
            transform.position += velocity * Time.deltaTime;
    }

    void UpdateInput()
    {
        velocity += GetAccelerationVector() * Time.deltaTime;

        Vector2 mouseDelta = LookSens * new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        Quaternion rot = transform.rotation;
        Quaternion hori = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
        Quaternion verti = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);
        transform.rotation = hori * rot * verti;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Focused = false;
        }

    }

    Vector3 GetAccelerationVector()
    {
        Vector3 moveInput = default;

        void AddMovement(KeyCode key, Vector3 dir)
        {
            if(Input.GetKey(key))
            {
                moveInput += dir;
            }
        }
        AddMovement(KeyCode.W, Vector3.forward);
        AddMovement(KeyCode.S, Vector3.back);
        AddMovement(KeyCode.D, Vector3.right);
        AddMovement(KeyCode.A, Vector3.left);
        AddMovement(KeyCode.Space, Vector3.up);
        AddMovement(KeyCode.LeftControl, Vector3.down);
        Vector3 dir = transform.TransformVector(moveInput.normalized);

        if(Input.GetKey(KeyCode.LeftShift))
        
            return dir *(Accel * AccSprintMultiplier);
        return dir * Accel;
    }
}
