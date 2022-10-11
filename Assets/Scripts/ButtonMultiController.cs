using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMultiController : MonoBehaviour
{
    [SerializeField]
    GameObject[] targets;
    public Color buttonColor = new Color(0f, 0f, 0f, 0.7f);
    // Update is called once per frame
    List<IUnderControl> components = new List<IUnderControl>();
    
    public void Start()
    {
        // Adding color to button
        ColorUnderControl cur_button = gameObject.GetComponent<ColorUnderControl>(); ;
        cur_button.SetBaseColor(buttonColor);
        // Adding it to components to get fade effect on toggle
        components.Add(cur_button);

        IUnderControl[] cur_components = { };
        if (targets != null) {
            foreach (var target in targets)
            {
                cur_components = target.GetComponents<IUnderControl>();
                foreach (var component in cur_components)
                {
                    Debug.LogWarning(component);
                    components.Add(component);
                    component.SetBaseColor(buttonColor);
                }
            }
        }

        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (components != null) {
            foreach (var component in components)
            {
                component.Toggle();
            }
        }
        
    }
            
 
}
