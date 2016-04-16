using UnityEngine;
using System.Collections;

public class BlockShape : Shape
{

    public new void Start()
    {
        base.Start();
        gameObject.AddComponent<BoxCollider2D>();
    }
}