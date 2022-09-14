using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private int jumps;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform playerFeet;
    public float checkRadius;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (isGrounded)
        {
            jumps = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (jumps > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumps--;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
        if ((!facingRight && moveInput > 0) || (facingRight && moveInput < 0))
        {
            flip();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, checkRadius, groundLayer);

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
