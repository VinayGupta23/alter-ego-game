using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Analytics.SetLevelName(SceneManager.GetActiveScene().name);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            //rb.bodyType = RigidbodyType2D.Static;
            //Destroy(rb.gameObject);
            //Thread.Sleep(1000);
            // Restarting the current level
            Analytics.RecordPlayerDeath();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Inside Finish");
            Debug.Log(Analytics.GetPlayerDeaths());
            Debug.Log(Analytics.GetCloneDeaths());
            Analytics.Save();
        }
    }
 
}