using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    private Transform transf;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform") &&
            this.transform.position.y > collision.transform.position.y)
        {
            gameObject.transform.parent = collision.transform;
            transf = collision.transform;
        }
        else if (transf == null &&
                 collision.transform.parent != null &&
                 collision.transform.parent.gameObject.CompareTag("MovingPlatform") &&
                 this.transform.position.y > collision.transform.position.y)
        {
            gameObject.transform.parent = collision.transform.parent.transform;
            transf = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (transf == collision.transform)
        {
            gameObject.transform.parent = null;
            transf = null;
        }
    }
}