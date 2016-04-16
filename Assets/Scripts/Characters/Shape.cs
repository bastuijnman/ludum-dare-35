using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour
{

    Character character;

    public float speed = 5.0f;

    // Use this for initialization
    public void Start()
    {

        DestroyImmediate(gameObject.GetComponent<CircleCollider2D>());
        DestroyImmediate(gameObject.GetComponent<BoxCollider2D>());

        character = gameObject.GetComponent<Character>();

        character.speed = speed;
    }
}
