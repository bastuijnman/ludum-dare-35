using UnityEngine;
using System.Collections;

public class BallShape : Shape
{

    public new void Start()
    {
        base.Start();
        shapeType = "ball";
        Rotation = true;
        maxSpeed = 10f;
        gameObject.AddComponent<CircleCollider2D>();
    }
}