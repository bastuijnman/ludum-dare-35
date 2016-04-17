using UnityEngine;
using System.Collections;

public class RotatingBlockShape : BlockShape
{

    void Update()
    {
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -5, 0);
    }
}
