using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Transform sphere; // Assign the sphere's transform here

    private Vector3 offset; // The initial offset from the sphere

    private void Start()
    {
        if (sphere != null)
        {
            // Calculate the initial offset
            offset = transform.position - sphere.position;
        }
        else
        {
            Debug.LogError("Sphere Transform is not assigned!");
        }
    }

    private void LateUpdate()
    {
        if (sphere != null)
        {
            // Update the position to follow the sphere without inheriting its rotation
            transform.position = sphere.position + offset;
            
            // Make the line face the camera - this is a simple billboard effect
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }
}