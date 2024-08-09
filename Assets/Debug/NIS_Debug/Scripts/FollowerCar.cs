using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCar : MonoBehaviour
{
    public GameObject TargetCar;
    public float moveSpeed;

    Vector3 currentPos;
    Vector3 newPos = Vector3.zero;

    private void Update()
    {
        transform.localPosition =
            Vector3.MoveTowards(transform.localPosition, newPos, moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        currentPos = newPos;
        newPos = TargetCar.transform.position;
    }
}
