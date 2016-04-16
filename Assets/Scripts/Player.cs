using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Movement speed, increase or decrease for faster movement
	public float speed = 3.0f;

	// Force at which the player can jump
	public float jumpForce = 3.0f;

	bool playerIsFalling = false;
	Vector3 movement;
	CircleCollider2D circleCollider;
    BoxCollider2D boxCollider;

    Transform transform;
    Rigidbody2D playerBody;
    SpriteImage spriteImageScript;

    public Sprite block;
    public Sprite circle;
    public Sprite line;

    public int spriteIndex = 0;
    public int availableTransforms = 3;

    void Start () {

        transform = gameObject.GetComponent<Transform> ();

        spriteImageScript = gameObject.AddComponent<SpriteImage> ();

        spriteImageScript.spriteImage = block;

        // Add a 2D rigid body so we can detect collisions
        playerBody = gameObject.AddComponent<Rigidbody2D> ();

        // Setup the 2D circle collider to detect collisions against the TileMap
        boxCollider = gameObject.AddComponent<BoxCollider2D> ();

	}

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
			playerBody.velocity = new Vector2 (0, jumpForce);
			playerIsFalling = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            spriteIndex++;

            if (spriteIndex == availableTransforms)
            {
                spriteIndex = 0;
            }

            DestroyImmediate(gameObject.GetComponent<CircleCollider2D>());
            DestroyImmediate(gameObject.GetComponent<BoxCollider2D>());

            switch (spriteIndex)
            {
                case 0:
                    spriteImageScript.spriteImage = block;

                    boxCollider = gameObject.AddComponent<BoxCollider2D>();

                    transform.localScale = new Vector3(2f, 2f, 1f);
                    break;
                case 1:
                    spriteImageScript.spriteImage = circle;

                    circleCollider = gameObject.AddComponent<CircleCollider2D>();
                    circleCollider.offset = Vector3.zero;
                    circleCollider.radius = 0.3f;

                    transform.localScale = new Vector3(1f, 1f, 1f);
                    break;
                case 2:
                    spriteImageScript.spriteImage = line;

                    transform.position = new Vector3(transform.position.x, 2f, transform.position.z);

                    transform.localScale = new Vector3(1f, 4f, 1f);

                    boxCollider = gameObject.AddComponent<BoxCollider2D>();
                    break;

            }
        }

        // Add to the current object position by updating movement with speed and game speed
        transform.position += movement * speed * Time.deltaTime;
	
	}

}
