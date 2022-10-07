using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
        if (target != null)
        {
            ColorUnderControl component = target.GetComponent<ColorUnderControl>();
            if (component!= null) {
                spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.color = component.GetBaseColor();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
