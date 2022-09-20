using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBase : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;
    protected RigidbodyType2D originalBodyType;

    private bool _isAlive = true;

    public bool IsAlive
    { 
        get { return _isAlive; }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        originalBodyType = rb.bodyType;
    }

    public void Die()
    {
        if (_isAlive == false)
        {
            // Player is already dead, do nothing
            return;
        }
        _isAlive = false;
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Die");
    }

    public void Revive()
    {
        if (_isAlive == true)
        {
            // Player is already alive, do nothing
            return;
        }
        _isAlive = true;
        rb.bodyType = originalBodyType;
        animator.SetTrigger("Revive");
    }

    public virtual void HandleDeathAnimDone() { }
}
