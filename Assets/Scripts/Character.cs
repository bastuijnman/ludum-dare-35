using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D body;

    // Movement speed, increase or decrease for faster movement
    public float speed = 0f;

    private int spriteIndex = 0;

    BoxCollider2D boxCollider;
    CircleCollider2D circleCollider;
    SpriteImage sprite;

    public string shape;
    Shape currentShape;

    public Sprite block;
    public Sprite circle;
    public Sprite line;

    public int availableTransforms = 3;

    void Start()
    {
        // Add a 2D rigid body so we can detect collisions
        body = gameObject.AddComponent<Rigidbody2D>();

        // Add the sprite image
        sprite = gameObject.AddComponent<SpriteImage>();

        Reshape(1);

    }

    public void Reshape(int index = -1)
    {
        if (index == -1)
        {
            spriteIndex++;

            if (spriteIndex == availableTransforms)
            {
                spriteIndex = 0;
            }
        } else
        {
            spriteIndex = index;
        }

        if (currentShape != null) {
        DestroyImmediate(currentShape);
            }

        switch (spriteIndex)
        {
            case 0:
                sprite.spriteImage = block;

                currentShape = gameObject.AddComponent<RotatingBlockShape>();

                transform.localScale = new Vector3(2f, 2f, 1f);
                break;
            case 1:
                sprite.spriteImage = circle;

                currentShape = gameObject.AddComponent<BallShape>();

                transform.localScale = new Vector3(2f, 2f, 1f);
                break;
            case 2:
                sprite.spriteImage = line;

                currentShape = gameObject.AddComponent<BlockShape>();

                transform.localScale = new Vector3(1f, 1f, 1f);
                break;

        }
    }
}
