using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello Worlds");   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(7, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-7, 0, 0);
        }

    }
}
