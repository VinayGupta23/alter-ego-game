using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusEffect
{
    SPEED_BOOST,
    FLIP_DIRECTION,
}

public class ApplyStatusEffect : MonoBehaviour
{
    public StatusEffect statusEffect;
    public float statusDuration;

    void OnTriggerEnter2D(Collider2D other){
         ReceiveStatusEffect receiver = other.gameObject.GetComponent<ReceiveStatusEffect>();
         if(receiver!=null)
         {
            receiver.ApplyEffect(statusEffect, statusDuration);
            Destroy(this.gameObject);
         }
    }
}
