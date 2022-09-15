using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            //rb.bodyType = RigidbodyType2D.Static;
            //Destroy(rb.gameObject);
            //Thread.Sleep(1000);
            // Restarting the current level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
 
}