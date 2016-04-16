using UnityEngine;
using System.Collections;

public class SpriteImage : MonoBehaviour
{

    public Sprite spriteImage;

    private SpriteRenderer spriteRenderer;

    void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite != spriteImage) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = spriteImage; // set the sprite to sprite1
    }

}
