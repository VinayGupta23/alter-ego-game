using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class PlayerLife : LifeBase
{
    public float cloneKillDelay = 0.3f;

    List<LifeBase> cloneLives = new List<LifeBase>();

    protected override void Start()
    {
        base.Start();

        foreach (GameObject clone in GameObject.FindGameObjectsWithTag("Clone"))
        {
            cloneLives.Add(clone.GetComponent<LifeBase>());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Analytics.Instance.RecordPlayerDeath(collision.gameObject.name, transform.position);
            Debug.Log("About to save from PlayerDeath");
            Analytics.Instance.Save();

            Die();
            SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Death);

            // Kill all clones as well, with some delay
            StartCoroutine(KillClones());
        }
    }

    IEnumerator KillClones()
    {
        if (cloneLives.Count > 0)
        {
            yield return new WaitForSeconds(cloneKillDelay);
            foreach (LifeBase cloneLife in cloneLives)
            {
                cloneLife.Die();
            }
        }
    }

    private void Update()
    {
        if (!IsAlive && !IsAnimating)
        {
            // Player death animation is complete, now check if any clones left to animate.
            // We need to check this dynamically because the clone could have died earlier
            // than the configured delay (due to collision with traps).
            bool allDead = cloneLives.TrueForAll(
                cloneLife => !cloneLife.IsAlive && !cloneLife.IsAnimating);
            if (allDead)
            {
                LevelManager.Instance.RestartLevel();
            }
        }
    }
}