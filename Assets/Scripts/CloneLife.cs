using UnityEngine;

public class CloneLife : LifeBase
{
    private Vector3 originalPosition;
    public GameObject spawner;

    protected override void Start()
    {
        base.Start();
        originalPosition = transform.position;

        Vector3 spawnPosition = originalPosition;
        Instantiate(spawner, spawnPosition, Quaternion.identity);
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