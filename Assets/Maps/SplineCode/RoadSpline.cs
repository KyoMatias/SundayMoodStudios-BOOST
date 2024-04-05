
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Splines;

[ExecuteInEditMode()]
public class RoadSpline : MonoBehaviour
{
    List<Vector3> m_vertsP1;
    List<Vector3> m_vertsP2;

    private SplineSampler m_splineSampler;
    
    [SerializeField] private int resolution;

    private void Awake() {
        BuildMesh();
    }

    // private void OnEnable() {
        
    //     Spline.Changed += OnSplineChanged;
    //     GetVerts();    
    // }

    // private void OnDisable() {
    //     Spline.Changed -= OnSplineChanged;
    // }

    // // private void OnSplineChanged(Spline arg1, int arg2, SplineModification arg3)
    // // {
    // //     Rebuild();
    // // }
    private void Update() {
    
    }


    private void GetVerts()
    {
        m_vertsP1 = new List<Vector3>();
        m_vertsP2 = new List<Vector3>();


        float step = 1f / (float)resolution;
        for (int i = 0; i < resolution; i++)
        {
            float t = step * i;
            m_splineSampler.SampleSplineWidth(t, out Vector3 p1, out Vector3 p2);
            m_vertsP1.Add(p1);
            m_vertsP2.Add(p2);
        }
    }

    private void BuildMesh()
    {
        Mesh m = new Mesh();
        List<Vector3>  verts = new List<Vector3>();
        List<int> tris = new List<int>();
        int offset = 0;

        int length = m_vertsP2.Count;
        for(int i = 1; i <= length; i++)
        {
            Vector3 p1 = m_vertsP1[i-1];
            Vector3 p2 = m_vertsP2[i-1];
            Vector3 p3;
            Vector3 p4;

            if( i == length)
            {
                p3 = m_vertsP1[0];
                p4 = m_vertsP2[0];
            }
            else 
            {
                p3 = m_vertsP1[i];
                p4 = m_vertsP2[i];
            }

            offset = 4 * (i-1);

            int t1 = offset + 0;
            int t2 = offset + 2;
            int t3 = offset + 3;

            int t4 = offset + 3;
            int t5 = offset + 1;
            int t6 = offset + 0;

            verts.AddRange(new List<Vector3> {p1, p2 ,p3, p4});
            tris.AddRange( new List<int> {t1,t2,t3,t4,t5,t6});
        }

        m.SetVertices(verts);
        m.SetTriangles(tris, 0);
        //m_meshfilter.mesh = m;
    }
}
