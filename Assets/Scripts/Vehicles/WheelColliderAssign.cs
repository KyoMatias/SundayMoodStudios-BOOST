using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class responsible for assigning wheel colliders and meshes for a vehicle
public class WheelColliderAssign : MonoBehaviour
{
    // Serializable class to hold references to wheel meshes
    [System.Serializable]
    public class WheelMesh
    {
        [Header("Wheel Meshes")]
        public MeshRenderer FrontLeftMesh;   // Mesh for the front left wheel
        public MeshRenderer FrontRightMesh;  // Mesh for the front right wheel
        public MeshRenderer RearLeftMesh;    // Mesh for the rear left wheel
        public MeshRenderer RearRightMesh;   // Mesh for the rear right wheel
    }

    // Serializable class to hold references to wheel colliders
    [System.Serializable]
    public class WheelCollisions
    {
        [Header("Wheel Colliders")]
        public WheelCollider FL; // Wheel collider for the front left wheel
        public WheelCollider FR; // Wheel collider for the front right wheel
        public WheelCollider RL; // Wheel collider for the rear left wheel
        public WheelCollider RR; // Wheel collider for the rear right wheel
    }

    // Public variables to hold the wheel meshes and colliders
    public WheelMesh Player_Wheels;         // Reference to the wheel meshes
    public WheelCollisions Player_WheelsCollider; // Reference to the wheel colliders

    // FixedUpdate is called at fixed intervals, typically used for physics updates
    private void FixedUpdate() {
        WheelPosition(); // Update the position and rotation of the wheels
    }

    // Method to update the position and rotation of all wheels
    public void WheelPosition()
    {
        // Update each wheel's position and rotation based on its corresponding collider
        WheelUpdate(Player_WheelsCollider.FR, Player_Wheels.FrontRightMesh);
        WheelUpdate(Player_WheelsCollider.FL, Player_Wheels.FrontLeftMesh);
        WheelUpdate(Player_WheelsCollider.RR, Player_Wheels.RearRightMesh);
        WheelUpdate(Player_WheelsCollider.RL, Player_Wheels.RearLeftMesh);
    }

    // Method to update the position and rotation of a specific wheel mesh
    public void WheelUpdate(WheelCollider collider, MeshRenderer wheelMeshRender)
    {
        Quaternion rot; // Variable to store the rotation of the wheel
        Vector3 position; // Variable to store the position of the wheel

        // Get the world position and rotation from the wheel collider
        collider.GetWorldPose(out position, out rot);

        // Set the position and rotation of the wheel mesh to match the collider
        wheelMeshRender.transform.position = position;
        wheelMeshRender.transform.rotation = rot;
    }
}