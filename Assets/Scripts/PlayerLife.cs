using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : LifeBase
{
    protected override void Start()
    {
        base.Start();
        Analytics.SetPlayerName("TestUser");
        Analytics.SetLevelName(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Analytics.RecordPlayerDeath();

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