using UnityEngine;
using System.Collections;

public class CircleShape : Shape
{
    Character character;

    public new void Start()
    {
        speed = 10f;
        base.Start();
        gameObject.AddComponent<CircleCollider2D>();
    }
    void Update()
    {
        character = gameObject.GetComponent<Character>();

        // Rotate the object around its local Y axis at 1 degree per second
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * speed * Time.deltaTime * -20, 0);

    }
}