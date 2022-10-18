using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float airMult;
    private float moveInput;
    private float lastInput;

    public float colXOffset;
    public float colYOffset;
    private Rigidbody2D rb;
    private Collider2D col;
    private bool facingRight = true;

    private bool isGrounded;
    public LayerMask groundLayer;

    private LifeBase life;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        life = GetComponent<LifeBase>();
    }

    void Update()
    {
        if (life.IsAlive == false)
        {
            // Don't register input if player is dead
            // This supresses warnings since we change the rigid body type on death
            return;
        }

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
        if (life.IsAlive == false)
        {
            return;
        }

        Vector2 max = col.bounds.max;
        Vector2 min = col.bounds.min;
        max.y -= colYOffset;
        max.x -= colXOffset;
        min.x += colXOffset;
        isGrounded = Physics2D.OverlapArea(min, max, groundLayer);

        List<Collider2D> colliders = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = false;
        filter.layerMask = LayerMask.GetMask("Default");
        filter.useLayerMask = true;
        Physics2D.OverlapCollider(col, filter, colliders);
        foreach (Collider2D c in colliders)
        {
            if (c.CompareTag("Door") && transform.position.y < c.bounds.max.y)
            {
                Vector3 pos = transform.position;
                Bounds colBounds = c.bounds;
                float maxCol = colBounds.max.x - pos.x;
                float minCol = colBounds.min.x - pos.x;
                if (maxCol > 0 && minCol < 0)
                {
                    if (maxCol > Math.Abs(minCol))
                    {
                        pos.x -= maxCol;
                    }
                    else
                    {
                        pos.x -= minCol;
                    }

                    transform.position = pos;
                }
            }
        }

        float targetSpeed = moveInput * speed;
        if (math.abs(moveInput) < lastInput)
        {
            if (math.abs(moveInput) < 0.2f)
            {
                targetSpeed = 0;
            }
            else
            {
                targetSpeed = rb.velocity.x/1.25f;
            }
        }
        
        lastInput = math.abs(moveInput);
        
        
        
        rb.velocity = new Vector2(targetSpeed, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        // BUG: This causes collisions to recompute, and is also incorrect.
        // transform.localScale *= -1;
    }
}
