using UnityEngine;
using System.Collections;

public class ShapeManager : MonoBehaviour
{
    Character character;
    SpriteImage sprite;

    private Sprite[] playerSprites = Resources.LoadAll<Sprite>("Tilesets/spritesheet_player");

    // The current scene index
    private int spriteIndex = 0;
    public int availableTransforms = 3;

    private Shape currentShape;

    void Start()
    {
        character = gameObject.GetComponent<Character>();

        // Add the sprite image
        sprite = gameObject.AddComponent<SpriteImage>();

        Reshape(0);

    }

    // Increments the scene index and loads the new scene
    public void Reshape(int index = -1)
    {
        if (index == -1)
        {
            spriteIndex++;

            if (spriteIndex == availableTransforms)
            {
                spriteIndex = 0;
            }
        }
        else
        {
            spriteIndex = index;
        }
        if (currentShape != null)
        {
            DestroyImmediate(currentShape);
        }

        switch (character.shapeList[spriteIndex])
        {
            case "block":
                sprite.spriteImage = playerSprites[1];

                currentShape = gameObject.AddComponent<RotatingBlockShape>();

                transform.localScale = new Vector3(2f, 2f, 1f);
                break;
            case "ball":
                sprite.spriteImage = playerSprites[3];

                currentShape = gameObject.AddComponent<BallShape>();

                transform.localScale = new Vector3(2f, 2f, 1f);

                break;
            case "line":
                sprite.spriteImage = playerSprites[0];

                currentShape = gameObject.AddComponent<BlockShape>();

                transform.localScale = new Vector3(2f, 2f, 1f);

                transform.position = new Vector3(transform.position.x, 3, transform.position.z);
                
                break;

        }
    }
}
