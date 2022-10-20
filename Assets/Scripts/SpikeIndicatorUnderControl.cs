using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeIndicatorUnderControl : MonoBehaviour, IUnderControl
{
    private Color targetColor = Color.clear;

    SpriteRenderer spriteRenderer;
    bool isActive = false;
    bool colorChangeNeeded = false;

    public bool IsActive
    {
        get { return isActive; }
    }

    public void SetBaseColor(Color color)
    {
        targetColor = color;
        colorChangeNeeded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.Find("SpikeColorIndicator").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colorChangeNeeded)
        {
            spriteRenderer.color = targetColor;
            colorChangeNeeded = false;
        }
    }

    public void Activate()
    {

    }

    public void Deactivate()
    {

    }

    public void Toggle()
    {

    }
}
