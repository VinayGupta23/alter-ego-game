using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("MovingPlatform") || 
             (collision.transform.parent != null && collision.transform.parent.gameObject.CompareTag("MovingPlatform"))) && 
            this.transform.position.y > collision.transform.position.y)
        {
            gameObject.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform") || 
            (collision.transform.parent != null && collision.transform.parent.gameObject.CompareTag("MovingPlatform")))
        {
            gameObject.transform.parent = null;
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
        foreach(Collider2D c in colliders)
        {
            if (c.CompareTag("Door"))
            {
                float maxCol = c.bounds.max.x - transform.position.x;
                float minCol = c.bounds.min.x - transform.position.x;
                if (maxCol > 0 && minCol < 0)
                {
                    Vector3 pos = transform.position;
                    if (maxCol > Math.Abs(minCol))
                    {
                        pos.x -= 0.5f;
                    }
                    else
                    {
                        pos.x += 0.5f;
                    }

                    transform.position = pos;
                }
            }
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        // BUG: This causes collisions to recompute, and is also incorrect.
        // transform.localScale *= -1;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("SpeedBoost"))
        {
            speed = speed*1.5f;
            Destroy(other.gameObject);
            StartCoroutine(StopSpeedUp());
        }
    }

    IEnumerator StopSpeedUp()
    {
        yield return new WaitForSeconds(2.5f);
        speed = speed/1.5f;
    }
}
