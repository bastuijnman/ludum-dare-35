using UnityEngine;
using System.Collections;

public class FlipBlock : MonoBehaviour
{
    public Sprite[] blockColors; //Assign the length of the array in the inspector,
                                 //and drag the sprites you want it to change to into each element.
    public int currentSprite = -1; //The int that tells us which sprite in the array
                                   //we will use.
    public bool deleting; //Unity doesn't actually delete an object until the next
                          //frame, so this will allow us to make sure the code doesn't break by having
                          //currentSprite be longer than the array length.
    private int arrayLength;

    void Start()
    {
        arrayLength = blockColors.Length - 1;
    }

    void OnCollisionEnter2D()
    {
        currentSprite += 1; // adds 1 to the "currentSprite" integer.

        Debug.logger.Log(currentSprite);
        Debug.logger.Log(arrayLength);

        if (currentSprite > arrayLength)
        { //Deletes the object if currentSprite is greater than the
          //length of the blockColors array
            deleting = true;
            GameObject.Destroy(gameObject);
        }
        if (!deleting)
        {
            GetComponent<SpriteRenderer>().sprite = blockColors[currentSprite]; //sets the SpriteRenderer's
                                                                                //Sprite to be the desired sprite in the blockColors array.
        }
    }
}