using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollection: MonoBehaviour
{
    private new SpriteRenderer renderer;
    private bool collected = false;

    private bool isConfigured = false;
    private Color fadeColor = new Color(0f, 0f, 0f, 0.7f);

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Ideally we want to do this once in Start()
        // Since order of execution of Start() is not guaranteed,
        // the managers may not be setup leading to race conditions.
        if (!isConfigured)
        {
            if (ProgressManager.Instance.GameProgress.IsGemCollected(LevelManager.Instance.GetCurrentLevel()))
            {
                renderer.color -= fadeColor;
                Collider2D collider = GetComponent<Collider2D>();
                collider.enabled = false;
                collider.isTrigger = false;
            }
            isConfigured = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Clone"))
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
