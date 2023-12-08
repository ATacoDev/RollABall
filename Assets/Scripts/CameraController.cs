using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// store a public reference to the Player game object, so we can refer to it's Transform
	public GameObject player;

	// Store a Vector3 offset from the player (a distance to place the camera from the player at all times)
	private Vector3 offset;

	// At the start of the game..
	void Start ()
	{
		// Create an offset by subtracting the Camera's position from the player's position
		offset = transform.position - player.transform.position;
	}

	// After the standard 'Update()' loop runs, and just before each frame is rendered..
	void LateUpdate ()
	{
		// follow the player from an angled point of view above the plane
		// transform.position = player.transform.position + offset;
		//move z coordinate backwards behind player
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 9, player.transform.position.z - 8);
	}
}