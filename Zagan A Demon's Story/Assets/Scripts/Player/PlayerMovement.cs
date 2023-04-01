using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 6;
    [SerializeField] private float JumpHeight = 10;

    private Rigidbody2D rb;
    private Animator anim;

    private float horizontalInput;
    private bool grounded;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        Move();
        FlipCharacter();

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        anim.SetBool("Grounded", grounded);
    }

    private void FlipCharacter()
    {
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(5, 5, 5);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-5, 5, 5);
    }

    private void Move()
    {
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        anim.SetBool("Run", horizontalInput != 0);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        anim.SetTrigger("Jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
