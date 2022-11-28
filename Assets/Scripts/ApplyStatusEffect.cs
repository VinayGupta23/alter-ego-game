using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum StatusEffect
{
    SPEED_BOOST,
    FLIP_DIRECTION,
}

public class ApplyStatusEffect : MonoBehaviour
{
    public StatusEffect statusEffect;
    public float statusDuration;

    void Start()
    {
        if (statusDuration == 0.0f)
        {
            this.gameObject.transform.Find("Timed").gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.PillStart);
        ReceiveStatusEffect receiver = other.gameObject.GetComponent<ReceiveStatusEffect>();
        if (receiver != null)
        {
            Analytics.Instance.RecordPillCollection();
            receiver.ApplyEffect(statusEffect, statusDuration);
            Destroy(this.gameObject);
        }

    }
}
