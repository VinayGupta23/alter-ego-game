using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    private GameObject player;
    private GameObject clone;

    [SerializeField]
    private Sprite usedPortal;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        clone = GameObject.FindWithTag("Clone");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Clone"))
        {
            (player.transform.position, clone.transform.position) =
                (clone.transform.position, player.transform.position);
            Collider2D collider = GetComponent<Collider2D>();
            collider.enabled = false;
            collider.isTrigger = false;
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = usedPortal;
            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Teleport);
        }
    }
}
