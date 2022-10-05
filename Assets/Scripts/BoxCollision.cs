using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
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
}
