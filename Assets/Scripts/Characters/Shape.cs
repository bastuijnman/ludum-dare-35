using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour
{
    public Character character;

    public float maxSpeed = 10.0f;

    // Use this for initialization
    public void Start()
    {
        DestroyImmediate(gameObject.GetComponent<CircleCollider2D>());
        DestroyImmediate(gameObject.GetComponent<BoxCollider2D>());

        character = gameObject.GetComponent<Character>();
    }

    // Auto-implemented properties.
    public bool Rotation { get; set; }
    public string shapeType { get; set; }
}
