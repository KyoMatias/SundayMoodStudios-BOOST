using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeParent : MonoBehaviour
{
  public Transform parent; // assign the parent object in the inspector
    public float gravityMultiplier = 1f; // adjust the gravity multiplier to your liking

    private Vector3 initialOffset;
    private float initialYPosition;

    void Awake() {
        initialYPosition = transform.position.y;
    }
    void Start()
    {
        // store the initial offset and y-position of the child object
        initialOffset = transform.position - parent.position;
        initialYPosition = transform.position.y;
    }

    void LateUpdate()
    {
        // calculate the new position of the child object, ignoring the y-axis movement of the parent
        Vector3 newPosition = parent.position + initialOffset;
        newPosition.y = initialYPosition + (Physics.gravity.y * gravityMultiplier * Time.deltaTime);

        // set the position and rotation of the child object
        transform.position = newPosition;
        transform.rotation = parent.rotation;
    }
}
