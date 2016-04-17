using UnityEngine;
using System.Collections;

public class Player : Character {

	// Force at which the player can jump
	float jumpForce = 3.0f;

	bool playerIsFalling = false;
	public Vector3 movement;

	void Update () {

		/*
		 * 
		 * Axis are mapped to standard Unity input mapping.
		 * Horizontal = A/D/Left/Right
		 * Vertical = W/S/Up/Down
		 * 
		 */
		movement = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, 0.0f);

		if (Input.GetButtonDown ("Jump") && !playerIsFalling) {
			body.velocity = new Vector2 (0, jumpForce);
			playerIsFalling = true;
        }

        /*
         * Reshapes the character when pressing left shift
         *
         */
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Reshape();
        }

        // Add to the current object position by updating movement with speed and game speed
        transform.position += movement * speed * Time.deltaTime;
	
	}

	void OnCollisionEnter2D (Collision2D col) {
		
		// We're colliding with something so we'll assume we've stopped falling for now
		playerIsFalling = false;
	}

}
