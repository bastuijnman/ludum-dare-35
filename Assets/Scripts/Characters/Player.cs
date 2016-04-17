using UnityEngine;
using System.Collections;

public class Player : Character {
    
    // Current speed of player
    public float currentSpeed = 0;

    float Acceleration = 1;
    float Deceleration = 1;

	// Force at which the player can jump
	float jumpForce = 3.0f;
    public Vector3 movement;

    bool playerIsFalling = false;

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

        if (Input.GetButtonDown("Jump") && !playerIsFalling)
        {
            body.velocity = new Vector2(0, jumpForce);
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
        if ((Input.GetKey("left")) && (Mathf.Abs(currentSpeed) < shapeManager.getCurrentShape().maxSpeed))
        {
            currentSpeed -= Acceleration;
        }
        else if ((Input.GetKey("right")) && (currentSpeed < shapeManager.getCurrentShape().maxSpeed))
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
            body.AddForceAtPosition(new Vector2(currentSpeed, 0), new Vector2(0, transform.localScale.y / 2));
        }
    }

	void OnCollisionEnter2D (Collision2D col) {
		
		// We're colliding with something so we'll assume we've stopped falling for now
		playerIsFalling = false;
	}

}
