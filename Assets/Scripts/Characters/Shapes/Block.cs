using UnityEngine;
using System.Collections;

public class BlockShape : Shape
{

    public new void Start()
    {
        base.Start();
        shapeType = "block";
        gameObject.AddComponent<BoxCollider2D>();
    }
}