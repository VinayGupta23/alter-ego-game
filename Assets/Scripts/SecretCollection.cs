using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCollection : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody;
    Collider2D collider2d;
    SecretWeapon secretWeapon;

    [SerializeField]
    protected GameObject deathRingPrefab;
    [SerializeField]
    protected Color deathRingTint;

    bool isConfigured;
    bool collected = false;

    public bool Collected
    {
        get { return collected; }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();

        secretWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<SecretWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ideally we want to do this once in Start()
        // Since order of execution of Start() is not guaranteed,
        // the managers may not be setup leading to race conditions.
        if (!isConfigured)
        {
            if (ProgressManager.Instance.GameProgress.IsSecretCollected(LevelManager.Instance.GetCurrentLevel()))
            {
                DisableSelf();
            }
            else
            {
                StartCoroutine(Chime());
            }
            isConfigured = true;
        }
    }

    void DisableSelf()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collected && collision.collider.CompareTag("Player"))
        {
            collected = true;
            secretWeapon.ReceivePiece();
            rigidBody.bodyType = RigidbodyType2D.Static;
            collider2d.enabled = false;
            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Gem);

            GameObject deathRing = GameObject.Instantiate(deathRingPrefab);
            deathRing.transform.position = transform.position;
            deathRing.GetComponent<SpriteRenderer>().color = deathRingTint;

            animator.SetTrigger("Pick");  // Disable happens through animation trigger
        }
    }

    IEnumerator Chime()
    {
        yield return new WaitForSeconds(1f);
        do
        {
            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Secret, 0.2f);
            yield return new WaitForSeconds(5.5f);
        }
        while (!collected);
    }
}
