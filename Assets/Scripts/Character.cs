using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D body;
    [HideInInspector] public ShapeManager shapeManager;

    void Start()
    {
        // Add a 2D rigid body so we can detect collisions
        body = gameObject.AddComponent<Rigidbody2D>();

        shapeManager = gameObject.AddComponent<ShapeManager>();

    }
}
