using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private int playerDeaths;
    private string playerName;
    private string level;
    public SaveObject saveObject;
    [SerializeField]private GameObject clone;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerDeaths = 0;
        playerName = "Ashutosh";
        level = SceneManager.GetActiveScene().name;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            //rb.bodyType = RigidbodyType2D.Static;
            //Destroy(rb.gameObject);
            //Thread.Sleep(1000);
            // Restarting the current level
            playerDeaths++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Inside Finish");
            saveObject = new SaveObject(playerName, level, playerDeaths, clone.GetComponent<CloneLife>().cloneDeaths);
            Debug.Log(saveObject.cloneDeaths);
            Analytics.Save(saveObject);
        }
    }
 
}