using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    private Vector2 moveInput;
    public Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speed = 10;
        jumpForce = 17;
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            jumpForce = jumpForce * -1;
            rb.gravityScale = rb.gravityScale * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Reset jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        //Hit a spike, player dies load the "Lost" scene
        if (collision.gameObject.CompareTag("Spike"))
        {
            SceneManager.LoadScene("PlayAgainLost");
        }

        //Completed the level and hit the endportal, load the "Won" scene
        if (collision.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene("PlayAgainWon");
        }
    }
}
