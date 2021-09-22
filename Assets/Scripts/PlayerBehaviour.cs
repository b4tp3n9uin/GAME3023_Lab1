using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed = 10;
    float MoveX, MoveY;

    // Update is called once per frame
    void Update() // Call the CheckCollision and the Move Function.
    {
        CheckCollision();
        Move();
    }

    void Move() // Move the player around the map
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(MoveX * speed * Time.deltaTime, MoveY * speed * Time.deltaTime, 0);
        transform.Translate(Movement);
    }

    void CheckCollision() // Extra thing I did, so the player dosen't go offscreen.
    {
        if (transform.position.x > 10.8)
            transform.position = new Vector3(10.6f, transform.position.y, 0);
        if (transform.position.x < -10.8)
            transform.position = new Vector3(-10.6f, transform.position.y, 0);
        if (transform.position.y > 4.3)
            transform.position = new Vector3(transform.position.x, 4.1f, 0);
        if (transform.position.y < -4.1)
            transform.position = new Vector3(transform.position.x, -3.9f, 0);
    }
}
