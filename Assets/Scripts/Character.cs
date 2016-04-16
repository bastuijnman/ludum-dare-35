using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D body;

    private int spriteIndex = 0;

    BoxCollider2D boxCollider;
    CircleCollider2D circleCollider;
    SpriteImage sprite;

    public string shape;

    public Sprite block;
    public Sprite circle;
    public Sprite line;

    public int availableTransforms = 3;

    void Start()
    {
        // Add a 2D rigid body so we can detect collisions
        body = gameObject.AddComponent<Rigidbody2D>();

        // Setup the 2D collider to detect collisions against the TileMap
        boxCollider = gameObject.AddComponent<BoxCollider2D>();

        // Add the sprite image
        sprite = gameObject.AddComponent<SpriteImage>();

    }

    public void Reshape()
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
                sprite.spriteImage = block;

                boxCollider = gameObject.AddComponent<BoxCollider2D>();

                transform.localScale = new Vector3(2f, 2f, 1f);
                break;
            case 1:
                sprite.spriteImage = circle;

                circleCollider = gameObject.AddComponent<CircleCollider2D>();
                circleCollider.offset = Vector3.zero;
                circleCollider.radius = 0.3f;

                transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 2:
                sprite.spriteImage = line;

                transform.position = new Vector3(transform.position.x, 2f, transform.position.z);

                transform.localScale = new Vector3(1f, 4f, 1f);

                boxCollider = gameObject.AddComponent<BoxCollider2D>();
                break;

        }
    }
}
