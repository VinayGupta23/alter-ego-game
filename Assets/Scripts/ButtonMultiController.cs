using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMultiController : MonoBehaviour
{
    [SerializeField]
    GameObject[] targets;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IUnderControl[] components = { };
        foreach (var target in targets)
        {   
            components = target.GetComponents<IUnderControl>();
            foreach (var component in components) {
                component.Toggle();
            }
            
        }
    }
}
