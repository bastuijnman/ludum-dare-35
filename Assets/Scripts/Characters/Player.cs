﻿using UnityEngine;
using System.Collections;

public class Player : Character {
    
    // Current speed of player
    public float currentSpeed = 0;

    float Acceleration = 1;
    float Deceleration = 1;

	// Force at which the player can jump
	float jumpForce = 200.0f;
    public Vector3 movement;

    bool playerIsFalling = false;

    private AudioClip jumpSound;

    void Update()
    {
        
        /*
		 * 
		 * Axis are mapped to standard Unity input mapping.
		 * Horizontal = A/D/Left/Right
		 * Vertical = W/S/Up/Down
		 * 
		 */
        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = new Quaternion(0, 0, 0, 0);

        if ((Input.GetAxis("Vertical") > 0 || Input.GetButtonDown("Jump")) && !playerIsFalling)
        {
            jumpSound = gameObject.GetComponent<AudioSource>().clip;
            gameObject.GetComponent<AudioSource>().PlayOneShot(jumpSound);
            body.AddForce(new Vector2(0, jumpForce));
            playerIsFalling = true;
        }

        /*
         * Reshapes the character when pressing left shift
         *
         */
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shapeManager.Reshape();

            body.transform.rotation = new Quaternion(0, 0, 0, 0);
            body.angularVelocity = 0;
        }
        if (Input.GetAxis("Horizontal") < 0 && (Mathf.Abs(currentSpeed) < shapeManager.getCurrentShape().maxSpeed))
        {
            currentSpeed -= Acceleration;
        }
        else if (Input.GetAxis("Horizontal") > 0 && (currentSpeed < shapeManager.getCurrentShape().maxSpeed))
        {
            currentSpeed += Acceleration;
        }
        else
        {
            if (currentSpeed > Deceleration)
                currentSpeed -= Deceleration;
            else if (currentSpeed < -Deceleration)
                currentSpeed += Deceleration;
            else
                currentSpeed = 0;
        }

        if (shapeManager.getCurrentShape().Rotation && shapeManager.getCurrentShape().shapeType == "block")
        {
            if (Mathf.Abs(body.angularVelocity) < 150 && currentSpeed != 0)
            {
                body.AddTorque(currentSpeed * Time.deltaTime * -150);
            }
        } else
        {
            body.AddForce(new Vector2(currentSpeed, 0));
        }
    }

	void OnCollisionEnter2D (Collision2D col) {
		
		// We're colliding with something so we'll assume we've stopped falling for now
		playerIsFalling = false;
	}

}
