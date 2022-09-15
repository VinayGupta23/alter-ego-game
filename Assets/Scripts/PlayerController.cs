using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    public float colXOffset;
    public float colYOffset;
    private Rigidbody2D rb;
    private Collider2D col;
    private bool facingRight = true;

    private bool isGrounded;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
        if ((!facingRight && moveInput > 0) || (facingRight && moveInput < 0))
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        Vector2 max = col.bounds.max;
        Vector2 min = col.bounds.min;
        max.y -= colYOffset;
        max.x -= colXOffset;
        min.x += colXOffset;
        isGrounded = Physics2D.OverlapArea(min, max, groundLayer);

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale *= -1;
    }
}
