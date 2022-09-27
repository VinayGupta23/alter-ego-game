using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderUnderControl : MonoBehaviour, IUnderControl
{
    BoxCollider2D boxCollider;

    public bool IsActive
    {
        get { return boxCollider.enabled == false; }
    }

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        boxCollider.enabled = false;
    }

    public void Deactivate()
    {
        boxCollider.enabled = true;
    }

    public void Toggle()
    {
        boxCollider.enabled = !boxCollider.enabled;
    }
}
