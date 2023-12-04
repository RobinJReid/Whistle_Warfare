using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2;
    void FixedUpdate()
    {
        // Moves the object forward at two units per second.
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
