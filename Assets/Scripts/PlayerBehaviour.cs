using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction
{
    FORWARD = 0, 
    LEFT = 1,
    BACKWARD = 2,
    RIGHT = 3
}

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 10;
    float MoveX, MoveY;
    Rigidbody2D rb;
    public Direction p_dir;
    public Animator anim;
    public bool isWalking = false;

    private bool isOnGrass = false;

    void Start()
    {
        GameSaver.OnSaveEvent.AddListener(SavePosition);
        GameSaver.OnLoadEvent.AddListener(LoadPosition);

        playWalkSound();
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

        //Animate the direction player is moving or idleing.
        if (MoveX > 0) //right
        {
            isWalking = true;
            p_dir = Direction.RIGHT;
            anim.SetBool("IsWalking", isWalking);
            anim.SetInteger("Direction", (int)p_dir);
        }
        else if (MoveX < 0) //left
        {
            isWalking = true;
            p_dir = Direction.LEFT;
            anim.SetBool("IsWalking", isWalking);
            anim.SetInteger("Direction", (int)p_dir);
        }
        else if (MoveY > 0) //Up
        {
            isWalking = true;
            p_dir = Direction.BACKWARD;
            anim.SetBool("IsWalking", isWalking);
            anim.SetInteger("Direction", (int)p_dir);
        }
        else if (MoveY < 0) //Down
        {
            isWalking = true;
            p_dir = Direction.FORWARD;
            anim.SetBool("IsWalking", isWalking);
            anim.SetInteger("Direction", (int)p_dir);
        }
        else //Idle
        {
            isWalking = false;
            anim.SetBool("IsWalking", isWalking);
            anim.SetInteger("Direction", (int)p_dir);
        }

        // Play Walking audio when player is walking.
        playWalkSound();

        Vector3 Movement = new Vector3(MoveX * speed * Time.deltaTime, MoveY * speed * Time.deltaTime, 0);
        transform.Translate(Movement);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("HIT Obstacle!");
            FindObjectOfType<AudioManager>().Play("Hit");
        }
        if (other.gameObject.CompareTag("Enemy")) // Collide with Enemy, Go to Battle Scene.
        {
            Debug.Log("HIT Enemy, Ouch!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            Debug.Log("Grass Enter");
            isOnGrass = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            Debug.Log("Grass Exit");
            isOnGrass = false;
        }
    }

    // Function that will turn on and off the audio clips for walking
    void playWalkSound()
    {
        if (isWalking)
        {
            if (isOnGrass) // Sound will change when you walk on Grass.
            {
                FindObjectOfType<AudioManager>().LoopSound("WalkGrass");
            }
            else
            {
                FindObjectOfType<AudioManager>().LoopSound("WalkNormal");
            }
                
        }
        else // Stop the walking sound from looping.
        { 
            if (isOnGrass)
                FindObjectOfType<AudioManager>().Stop("WalkGrass");
            else
                FindObjectOfType<AudioManager>().Stop("WalkNormal");
        }

    }
    

    // Save Position
    void SavePosition()
    {
        PlayerPrefs.SetString("Position", "Hello!");
        Debug.Log("Position Saved");
    }
    
    // Load Position
    void LoadPosition()
    {
        PlayerPrefs.GetString("Position", "");
        Debug.Log("Position Loaded");
    }
}
