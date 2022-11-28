using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollection: MonoBehaviour
{
    private new SpriteRenderer renderer;
    private new Collider2D collider;
    private bool collected = false;

    public bool Collected
    {
        get { return collected; }
    }

    private bool isConfigured = false;
    private Color fadeColor = new Color(0f, 0f, 0f, 0.7f);

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
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
            Analytics.Instance.RecordGemCollection();
            collected = true;
            renderer.enabled = false;
            collider.enabled = false;
            collider.isTrigger = false;

            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Gem);
        }


    }
}
