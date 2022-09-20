using UnityEngine;

public class CloneLife : LifeBase
{
    private Vector3 originalPosition;

    protected override void Start()
    {
        base.Start();
        originalPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }

    public override void HandleDeathAnimDone()
    {
        Revive();
        transform.position = originalPosition;
    }
}