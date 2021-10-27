using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed = 10;
    float MoveX, MoveY;
    Rigidbody2D rb;

    void Start()
    {
        GameSaver.OnSaveEvent.AddListener(SavePosition);
        GameSaver.OnLoadEvent.AddListener(LoadPosition);
    }

    // Update is called once per frame
    void Update() // Call the CheckCollision and the Move Function.
    {
        Move();
        rb = GetComponent<Rigidbody2D>();
    }

    void Move() // Move the player around the map
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(MoveX * speed * Time.deltaTime, MoveY * speed * Time.deltaTime, 0);
        transform.Translate(Movement);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("HIT Obstacle!");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT Enemy, Ouch!");
            transform.position = new Vector3(0, 0, 0);
        }
    }

    void CheckCollision() // This was for lab 1. But I made the Map Bigger for Lab 2.
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
    

    void SavePosition()
    {
        PlayerPrefs.SetString("Position", "Hello!");
        Debug.Log("Position Saved");
    }
    
    void LoadPosition()
    {
        PlayerPrefs.GetString("Position", "");
        Debug.Log("Position Loaded");
    }
}
