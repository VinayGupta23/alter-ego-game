using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveStatusEffect : MonoBehaviour
{
    private PlayerController controller;
    private SpriteRenderer render;
    public void ApplyEffect(StatusEffect statusEffect, float duration)
    {
        switch(statusEffect)
        {
            case StatusEffect.SPEED_BOOST:
                controller.speed *= 1.5f;
                render.color = Color.green;
                if(duration!=0.0f){
                    StartCoroutine(StopEffect(1.5f, duration));
                }
                break;

            case StatusEffect.FLIP_DIRECTION:
                controller.speed *= -1.0f;
                render.color = Color.green;
                if(duration!=0.0f){
                    StartCoroutine(StopEffect(-1.0f, duration));
                }
                break;
        }

    }

    IEnumerator StopEffect(float speedChange, float duration)
    {
        yield return new WaitForSeconds(duration);
        controller.speed /= speedChange;
        render.color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        render = GetComponent<SpriteRenderer>();
    }

}
