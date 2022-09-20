using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : LifeBase
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }

    public override void HandleDeathAnimDone()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}