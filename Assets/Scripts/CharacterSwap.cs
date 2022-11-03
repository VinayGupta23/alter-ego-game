using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    private GameObject player;
    private GameObject clone;
    private float timer = 0.0f;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        clone = GameObject.FindWithTag("Clone");
    }

    void FixedUpdate()
    {
        if (timer > 0.0f)
        {
            timer -= 0.02f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (timer <= 0.0f && (other.CompareTag("Player") || other.CompareTag("Clone")))
        {
            (player.transform.position, clone.transform.position) =
                (clone.transform.position, player.transform.position);
            timer = 0.1f;
        }
    }
}
