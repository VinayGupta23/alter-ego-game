using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;

    private bool isOpen = false;
    private Color openedFadeColor = new Color(0f, 0f, 0f, 0.7f);

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDoor()
    {
        if (isOpen)
        {
            // Already open, so close the door
            boxCollider.enabled = true;
            spriteRenderer.color += openedFadeColor;
        }
        else
        {
            // Door is closed, so open it
            boxCollider.enabled = false;
            spriteRenderer.color -= openedFadeColor;
        }
        isOpen = !isOpen;
    }
}
