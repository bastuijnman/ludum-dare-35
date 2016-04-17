using UnityEngine;
using System.Collections;

public class BallShape : Shape
{

    public new void Start()
    {
        speed = 10f;
        base.Start();
        gameObject.AddComponent<CircleCollider2D>();
    }
    void Update()
    {
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * speed / 2 * -1, 0);

    }
}