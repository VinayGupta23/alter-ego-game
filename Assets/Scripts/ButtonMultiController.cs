using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMultiController : MonoBehaviour
{
    [SerializeField]
    GameObject[] targets;
    // Update is called once per frame
    List<IUnderControl> components = new List<IUnderControl>();
    
    public void Start()
    {
        IUnderControl[] cur_components = { };
        foreach (var target in targets) {
            cur_components = target.GetComponents<IUnderControl>();
            foreach (var component in cur_components) {
                components.Add(component);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        foreach (var component in components)
        {
            component.Toggle();
        }
    }
            
 
}
