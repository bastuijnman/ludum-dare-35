using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShapeManager : MonoBehaviour
{
    SpriteImage sprite;

    private Sprite[] playerSprites = Resources.LoadAll<Sprite>("Tilesets/spritesheet_player");

    private List<string> shapeList = new List<string> {
        "block",
        "ball",
        "line",
        "tiny",
        "big"
    };

    // The current scene index
    private int spriteIndex = 0;

    private Shape currentShape;

    void Start()
    {
        // Add the sprite image
        sprite = gameObject.AddComponent<SpriteImage>();

        Reshape(0);

    }

    public void UnlockShape(string shape)
    {
        if (shapeList.IndexOf(shape) == -1)
        {
            shapeList.Add(shape);
        }
    }

    public List<string> GetUnlockedShapes()
    {
        return shapeList;
    }

    public Shape getCurrentShape()
    {
        return currentShape;
    }

    public void Reshape(int index = -1)
    {
        if (index == -1)
        {
            spriteIndex++;

            if (spriteIndex == GetUnlockedShapes().Count)
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

        switch (shapeList[spriteIndex])
        {
            case "block":
                sprite.spriteImage = playerSprites[1];

                currentShape = gameObject.AddComponent<BlockShape>();
                currentShape.Rotation = true;

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

                currentShape.maxSpeed = 7.5f;

                transform.localScale = new Vector3(2f, 2f, 1f);

                transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                
                break;
            case "tiny":
                sprite.spriteImage = playerSprites[4];

                currentShape = gameObject.AddComponent<BlockShape>();

                transform.localScale = new Vector3(0.9f, 0.9f, 1f);
                break;
            case "big":
                sprite.spriteImage = playerSprites[1];

                currentShape = gameObject.AddComponent<BlockShape>();

                currentShape.maxSpeed = 4f;

                transform.localScale = new Vector3(4f, 4f, 1f);
                break;
        }
    }
}
