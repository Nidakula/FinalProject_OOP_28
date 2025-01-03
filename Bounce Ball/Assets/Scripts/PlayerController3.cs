using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController3 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Vector3 respawnPoint;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Scoring.totalScore = 0;
        player = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        scoreText.text = "Rings Collected: " + Scoring.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, -jumpSpeed);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Spike")
        {
            transform.position = respawnPoint;
        } 
        else if(collision.tag == "Ring")
        {
            Scoring.totalScore += 1;
            scoreText.text = "Rings Collected: " + Scoring.totalScore;
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag == "Main menu")
        {
            SceneManager.LoadScene(0);
            respawnPoint = transform.position;
        }
        else if(collision.tag == "Level 1")
        {
            SceneManager.LoadScene(1);
            respawnPoint = transform.position;
        }
        else if(collision.tag == "Level 2")
        {
            SceneManager.LoadScene(2);
            respawnPoint = transform.position;
        }
        else if(collision.tag == "Level 3")
        {
            SceneManager.LoadScene(3);
            respawnPoint = transform.position;
        }
    }
}

    
