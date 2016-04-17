using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D body;

    // Movement speed, increase or decrease for faster movement
    public float speed = 0f;

    [HideInInspector] public ShapeManager shapeManager;

    [HideInInspector] public List<string> shapeList = new List<string> {
        "block",
        "ball",
        "line"
    };



    void Start()
    {
        // Add a 2D rigid body so we can detect collisions
        body = gameObject.AddComponent<Rigidbody2D>();

        shapeManager = gameObject.AddComponent<ShapeManager>();

    }
}
