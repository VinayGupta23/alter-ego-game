using UnityEngine;

public class CloneLife : LifeBase
{
    public GameObject spawner;

    private Vector3 originalPosition;
    private LifeBase playerLifeRef;

    protected override void Start()
    {
        base.Start();
        originalPosition = transform.position;
        playerLifeRef = GameObject.FindWithTag("Player").GetComponent<LifeBase>();

        Vector3 spawnPosition = originalPosition;
        Instantiate(spawner, spawnPosition, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Analytics.Instance.RecordCloneDeath();
            Die();
        }
    }

    public override void HandleDeathAnimDone()
    {
        base.HandleDeathAnimDone();

        if (playerLifeRef.IsAlive == false)
        {
            // The player died while the clone was animating
            // No need to revive the clone anymore
            return;
        }

        Revive();
        transform.position = originalPosition;
    }
}