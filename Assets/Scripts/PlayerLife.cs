using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

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
            Analytics.Instance.RecordPlayerDeath(collision.gameObject.name, transform.position);
            Debug.Log("About to save from PlayerDeath");
            Analytics.Instance.Save();

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