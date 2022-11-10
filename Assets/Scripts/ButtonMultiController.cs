using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMultiController : MonoBehaviour
{
    private ColorUnderControl  colorundercontrol;

    [SerializeField]
    GameObject[] targets;
    public  Constants.GameColors buttonColor = Constants.GameColors.Neutral;
    // Update is called once per frame
    List<IUnderControl> components = new List<IUnderControl>();

    DateTime lastCollionDate = DateTime.Now;

    public void Start()
    {
        // Adding color to button 
        
        ColorUnderControl cur_button = gameObject.GetComponent<ColorUnderControl>(); ;
        if (cur_button != null) {
            //Debug.LogWarning(cur_button.GetBaseColor());
            cur_button.SetBaseColor(Constants.COLOR_OPTIONS[(int)buttonColor]);
            //Debug.LogWarning(cur_button.GetBaseColor());
            // Adding it to components to get fade effect on toggle
            components.Add(cur_button);
        }

        IUnderControl[] cur_components = { };
        if (targets != null) {
            foreach (var target in targets)
            {
                cur_components = target.GetComponents<IUnderControl>();
                foreach (var component in cur_components)
                {
                   // Debug.LogWarning(component);
                    components.Add(component);
                    component.SetBaseColor(Constants.COLOR_OPTIONS[(int)buttonColor]);
                }
            }
        }

        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var timeDelta = (DateTime.Now - lastCollionDate).TotalMilliseconds;
        if (timeDelta > 1000)
        {
            if (components != null)
            {
                foreach (var component in components)
                {
                    component.Toggle();
                }
            }

        }
        lastCollionDate = DateTime.Now;
        
        
    }
            
 
}
