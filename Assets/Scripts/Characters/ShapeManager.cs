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
		"line-horizontal",
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

	public Sprite GetSpriteByName (string name) {
		switch (name) 
		{
			case "block":
				return playerSprites [2];

			case "ball":
				return playerSprites [4];

			case "line-horizontal":
				return playerSprites [1];

			case "line":
				return playerSprites [0];

			case "tiny":
				return playerSprites [5];

			case "big":
				return playerSprites[6];
		}
		return new Sprite ();
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

        transform.localScale = new Vector3(1f, 1f, 1f);

        switch (shapeList[spriteIndex])
        {
            case "block":
                sprite.spriteImage = GetSpriteByName("block");

                currentShape = gameObject.AddComponent<BlockShape>();
                currentShape.Rotation = true;

                break;
            case "ball":
                sprite.spriteImage = GetSpriteByName("ball");

                currentShape = gameObject.AddComponent<BallShape>();

                break;
            case "line-horizontal":
                sprite.spriteImage = GetSpriteByName("line-horizontal");

                currentShape = gameObject.AddComponent<BlockShape>();

                currentShape.maxSpeed = 7.5f;

                break;
            case "line":
                sprite.spriteImage = GetSpriteByName("line");

                currentShape = gameObject.AddComponent<BlockShape>();

                currentShape.maxSpeed = 7.5f;

                break;
            case "tiny":
                sprite.spriteImage = GetSpriteByName("tiny");

                currentShape = gameObject.AddComponent<BlockShape>();

                transform.localScale = new Vector3(0.45f, 0.45f, 1f);
                break;
            case "big":
                sprite.spriteImage = GetSpriteByName("big");

                currentShape = gameObject.AddComponent<BlockShape>();

                currentShape.maxSpeed = 4f;

                transform.localScale = new Vector3(2f, 2f, 1f);
                break;
        }
    }
}
