using UnityEngine;
using System.Collections;

public class SpriteImage : MonoBehaviour
{

    private Sprite[] spriteSheet = Resources.LoadAll<Sprite>("Tilesets/spritesheet_items");
    private SpriteRenderer spriteRenderer;

    public Sprite spriteImage;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (spriteImage == null)
        {
            return;
        }
        if (spriteRenderer.sprite != spriteImage)
        {
            spriteRenderer.sprite = spriteImage;
        }
    }

}
