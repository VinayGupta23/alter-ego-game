using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollection: MonoBehaviour
{
    private new SpriteRenderer renderer;
    private bool collected = false;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        if (ProgressManager.Instance.GameProgress.IsGemCollected(LevelManager.Instance.GetCurrentLevel()))
        {
            renderer.color = Color.grey;
            Collider2D collider = GetComponent<Collider2D>();
            collider.enabled = false;
            collider.isTrigger = false;
        }
        else
        {
            renderer.color = Color.red;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collected = true;
            renderer.enabled = false;
        }
    }

    public bool IsCollected()
    {
        return collected;
    }
}
