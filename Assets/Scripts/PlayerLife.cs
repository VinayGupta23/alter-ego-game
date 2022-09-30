using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : LifeBase
{
    protected override void Start()
    {
        base.Start();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Analytics.Instance.RecordPlayerDeath();

            Die();
            // Kill all clones as well
            foreach (GameObject clone in GameObject.FindGameObjectsWithTag("Clone"))
            {
                clone.GetComponent<LifeBase>().Die();
            }
        }
    }

    public override void HandleDeathAnimDone()
    {
        LevelManager.Instance.RestartLevel();
    }
}