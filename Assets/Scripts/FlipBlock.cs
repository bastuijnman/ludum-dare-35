﻿using UnityEngine;
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

    private bool hasCollide = false;

    void Start() {
        arrayLength = blockColors.Length - 1;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player"){
            if (hasCollide == false)
            {
                hasCollide = true;
                currentSprite += 1;
                GetComponent<SpriteRenderer>().sprite = blockColors[currentSprite];
            }
        }
    }

    void OnCollisionExit2D()
    {
        hasCollide = false;
    }
}