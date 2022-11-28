using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveStatusEffect : MonoBehaviour
{
    private PlayerController controller;
    private SpriteRenderer render;
    private GameObject Speed;
    private GameObject Reverse;
    private GameObject Timer;
    private Color statusColor = Color.white;

    public void ApplyEffect(StatusEffect statusEffect, float duration)
    {
        switch(statusEffect)
        {
            case StatusEffect.SPEED_BOOST:
                ShowBoostSymbol(Speed);
                controller.speed *= 1.5f;
                render.color = statusColor;
                if(duration!=0.0f){
                    ShowBoostSymbol(Timer);
                    StartCoroutine(StopEffect(1.5f, duration, Speed));
                }
                break;

            case StatusEffect.FLIP_DIRECTION:
                if (CheckBoost(Reverse)==false)
                {
                    ShowBoostSymbol(Reverse);
                    controller.speed *= -1.0f;
                    render.color = statusColor;
                    if(duration!=0.0f){
                        ShowBoostSymbol(Timer);
                        StartCoroutine(StopEffect(-1.0f, duration, Reverse));
                    }
                    break;
                }
                else{
                    HideBoostSymbol(Timer);
                    HideBoostSymbol(Reverse);
                    controller.speed *= -1.0f;
                    break;
                }
        }

    }

    IEnumerator StopEffect(float speedChange, float duration, GameObject boostGameObject)
    {
        yield return new WaitForSeconds(duration);
        controller.speed /= speedChange;
        render.color = Color.white;
        HideBoostSymbol(boostGameObject);
        HideBoostSymbol(Timer);
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        render = GetComponent<SpriteRenderer>();
        Speed = this.gameObject.transform.Find("Speed").gameObject;
        Reverse = this.gameObject.transform.Find("Reverse").gameObject;
        Timer = this.gameObject.transform.Find("Timer").gameObject;
        HideBoostSymbol(Speed);
        HideBoostSymbol(Reverse);
        HideBoostSymbol(Timer);
    }

    void ShowBoostSymbol(GameObject boostGameObject)
    {
        boostGameObject.SetActive(true);
    }
    
    void HideBoostSymbol(GameObject boostGameObject)
    {
        boostGameObject.SetActive(false);
    }

    bool CheckBoost(GameObject boostGameObject)
    {
        if(boostGameObject.activeSelf)
        {
            return true;
        }
        else{
            return false;
        }
        
    }
}
