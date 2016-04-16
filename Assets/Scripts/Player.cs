using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Movement speed, increase or decrease for faster movement
	public float speed = 3.0f;

	// Collision radius, change this property to play around with collision detection
	public float collisionRadius = 0.5f;

	Vector3 movement;
	CircleCollider2D playerCollider;
	Rigidbody2D playerBody;


	void Start () {

		// Add a 2D rigid body so we can detect collisions
		playerBody = gameObject.AddComponent<Rigidbody2D> ();

		// Setup the 2D circle collider to detect collisions against the TileMap
		playerCollider = gameObject.AddComponent<CircleCollider2D> ();
		playerCollider.offset = Vector3.zero;
		playerCollider.radius = collisionRadius;

	}

	void Update () {

		/*
		 * 
		 * Axis are mapped to standard Unity input mapping.
		 * Horizontal = A/D/Left/Right
		 * Vertical = W/S/Up/Down
		 * 
		 */
		movement = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);

		// Add to the current object position by updating movement with speed and game speed
		transform.position += movement * speed * Time.deltaTime;
	
	}

}
