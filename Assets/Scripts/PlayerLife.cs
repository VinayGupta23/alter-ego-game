using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : LifeBase
{
    protected virtual void Start()
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
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("In Finish");
            Debug.Log("Player Name: " + Analytics.GetPlayerName());
            Debug.Log("Level: " + Analytics.GetLevel());
            Debug.Log("Player Deaths: " + Analytics.GetPlayerDeaths());
            Debug.Log("Clone Deaths: " + Analytics.GetCloneDeaths());
            Analytics.Save();
        }
    }

    public override void HandleDeathAnimDone()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}