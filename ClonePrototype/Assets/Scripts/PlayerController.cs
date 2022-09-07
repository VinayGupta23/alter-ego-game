using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;

    private float horizontal;
    private Rigidbody2D playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Vector2 newVelocity = playerBody.velocity;
        newVelocity.x = speed * horizontal;
        playerBody.velocity = newVelocity;    

        /*
        Vector2 newPosition = playerBody.position;
        newPosition.x += speed * horizontal * Time.fixedDeltaTime;
        // newPosition.y += gravity * Time.fixedDeltaTime;
        // playerBody.MovePosition(newPosition);

        newPosition += Physics2D.gravity * playerBody.gravityScale

        playerBody.AddForce(new Vector2(speed * horizontal, 0), ForceMode2D.Impulse);
        */
    }
}
