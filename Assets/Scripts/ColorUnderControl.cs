using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUnderControl : MonoBehaviour, IUnderControl
{
    public enum ControllerColor
    {
        Neutral = 0,
        Accent1 = 1,
        Accent2 = 2
    }

    public static readonly Color[] COLOR_OPTIONS = {
        new Color(1, 1, 1), // No change
        new Color(1, 0.9231956f, 0.7882353f), // Tint yellow
        new Color(1, 0.7882353f, 0.9254902f), // Tint pink
    };

    [SerializeField]
    private ControllerColor controllerColor = ControllerColor.Neutral;
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
        return COLOR_OPTIONS[(int)controllerColor];
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
