using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    IUnderControl[] controlComponents = { };

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning(string.Format("Button controller \"{0}\" does not have a target configured in Unity.", name));
        }

        // If target is not configured in the editor, use fallback approach based on name search
        if ((target == null) && name.StartsWith("Key"))
        {
            target = GameObject.Find("Door" + name.Substring(3));
            if (target)
            {
                Debug.LogWarning(string.Format("Button controller \"{0}\" paired with \"{1}\" by fallback.", name, target.name));
            }
        }

        if (target)
        {
            controlComponents = target.GetComponents<IUnderControl>();

            // Update button color if the target has color control
            ColorUnderControl colorControl = target.GetComponent<ColorUnderControl>();
            if (colorControl)
            {
                GetComponent<SpriteRenderer>().color = colorControl.GetBaseColor();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var component in controlComponents)
        {
            component.Toggle();
        }
    }
}
