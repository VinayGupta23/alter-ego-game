using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWeapon : MonoBehaviour
{
    bool isConfigured = false;
    bool weaponUnlocked = false;
    int ownedSecrets = 0;
    List<LifeBase> cloneLives = new List<LifeBase>();

    [SerializeField]
    Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    bool piecePicked = false;
    int showTargetSprite = 1;
    float timeSinceChanged = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        foreach (GameObject clone in GameObject.FindGameObjectsWithTag("Clone"))
        {
            cloneLives.Add(clone.GetComponent<LifeBase>());
        }

        if (sprites.Length != (Constants.TotalSecrets + 1))
        {
            Debug.LogWarning("Number of player sprites does not match secrets. Will not load!");
            // Prevent config from running due to invalid sprite sheet
            isConfigured = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isConfigured)
        {
            ownedSecrets = ProgressManager.Instance.GameProgress.Secrets();
            spriteRenderer.sprite = sprites[ownedSecrets];

            if (LevelDependency.Instance.DMInstance.FreeMode)
            {
                weaponUnlocked = true;
            }
            else
            {
                weaponUnlocked = (ownedSecrets == Constants.TotalSecrets);
            }

            isConfigured = true;
        }

        if (piecePicked)
        {
            timeSinceChanged += Time.deltaTime;

            if (timeSinceChanged >= 0.25f)
            {
                showTargetSprite = 1 - showTargetSprite;
                spriteRenderer.sprite = sprites[ownedSecrets + showTargetSprite];
                timeSinceChanged = 0f;
            }
        }

        if (weaponUnlocked && Input.GetKeyDown(KeyCode.F))
        {
            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.CloneDeath);
            foreach (LifeBase cloneLife in cloneLives)
            {
                cloneLife.Die();
            }
        }
    }

    public void ReceivePiece()
    {
        piecePicked = true;
    }
}
