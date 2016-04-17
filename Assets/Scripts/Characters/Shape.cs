using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour
{
    public Character character;

    private bool rotationEnabled = false;
    private string type = "shape";

    public float maxSpeed = 10.0f;

    // Use this for initialization
    public void Start()
    {
        DestroyImmediate(gameObject.GetComponent<CircleCollider2D>());
        DestroyImmediate(gameObject.GetComponent<BoxCollider2D>());

        character = gameObject.GetComponent<Character>();
    }

    public bool Rotation
    {
        get
        {
            return rotationEnabled;
        }
        set
        {
            rotationEnabled = value;
        }
    }

    public string shapeType
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }
}
