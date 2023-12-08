using UnityEngine;

public class FlashlightAim : MonoBehaviour
{
    // Reference to the player or sphere GameObject (drag the player/sphere GameObject into this field in the Inspector)
    public GameObject player;

    // Update is called once per frame
    void Update()
    {


        if (player != null)
        {
            // Get the player's rigidbody component (your movement script)
            Rigidbody rb = player.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Get the direction of the player's movement
                Vector3 movementDirection = rb.velocity;

                // Calculate the rotation to face the movement direction
                Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

                // Apply the rotation to the flashlight
                transform.rotation = targetRotation;
            }
        }
    }
}
