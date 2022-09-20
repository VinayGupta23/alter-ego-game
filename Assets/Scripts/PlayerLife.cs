using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : LifeBase
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}