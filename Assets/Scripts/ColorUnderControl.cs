using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUnderControl : MonoBehaviour, IUnderControl
{
    [SerializeField]
    private Constants.GameColors controllerColor = Constants.GameColors.Neutral;
    public bool fadeOnActive = true;
    public Color fadeColor = new Color(0f, 0f, 0f, 0.7f);

    SpriteRenderer spriteRenderer;
    bool isActive = false;

    bool isColorSet = false;
    public bool IsActive
    {
        get { return isActive; }
    }

    public Color GetBaseColor()
    {
        return Constants.COLOR_OPTIONS[(int)controllerColor];
    }

    public void SetBaseColor(Color color) {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
        isColorSet = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isColorSet == false) {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = GetBaseColor();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        if (fadeOnActive)
        {
            spriteRenderer.color -= fadeColor;
            isActive = true;
        }
    }

    public void Deactivate()
    {
        if (fadeOnActive)
        {
            spriteRenderer.color += fadeColor;
            isActive = false;
        }
    }

    public void Toggle()
    {
        if (isActive)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }
}
