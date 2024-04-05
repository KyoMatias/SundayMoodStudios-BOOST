using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;

[ExecuteInEditMode]
public class SplineSampler : MonoBehaviour
{
    [SerializeField] 
    private SplineContainer m_splineContainer;

    [SerializeField]
    private int m_splineIndex;
    [SerializeField]
    [Range(0f, 1f)]
    private float m_time;

    float3 position;
    float3 forward;
    float3 upVector;
    public float m_width;

    public Vector3 p1;
    public Vector3 p2;

    private void Update() {
        m_splineContainer.Evaluate(m_splineIndex, m_time , out position, out forward, out upVector);

        float3 right = Vector3.Cross(forward, upVector).normalized;
        p1 = position + (right * m_width);
        p2 = position + (-right * m_width);
        
    }

    private void OnDrawGizmos() {
        Handles.matrix = transform.localToWorldMatrix;
        Handles.SphereHandleCap(0, p1, Quaternion.identity, 1f, EventType.Repaint);
        Handles.SphereHandleCap(0, p2, Quaternion.identity, 1f, EventType.Repaint);
    }

    public void SampleSplineWidth(float t, out Vector3 point1, out Vector3 point2)
    {
        point1 = p1;
        point2 = p2;
    }
}
