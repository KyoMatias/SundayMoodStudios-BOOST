using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Body
{
    public Mesh BodyMesh;
    public float FrontWheelDisplacement;
}

public class BodySwitcher : MonoBehaviour
{
    public Mesh[] CarMesh;
    public MeshFilter MeshFilter;
    public int Counter;

    public Body ToSwap;

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwapCarMesh(ToSwap);
    }

    void SwapCarMesh(Body swap)
    {
        MeshFilter.mesh = swap.BodyMesh;
        // wheels = swap.Wheels;
    }
}
