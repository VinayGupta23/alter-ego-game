using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollection: MonoBehaviour
{
    private new SpriteRenderer renderer;
    private bool collected = false;

    private Color fadeColor = new Color(0f, 0f, 0f, 0.7f);

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        if (ProgressManager.Instance.GameProgress.IsGemCollected(LevelManager.Instance.GetCurrentLevel()))
        {
            renderer.color -= fadeColor;
            Collider2D collider = GetComponent<Collider2D>();
            collider.enabled = false;
            collider.isTrigger = false;
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
