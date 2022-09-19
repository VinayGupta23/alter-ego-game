using UnityEngine;

public class CloneLife : MonoBehaviour
{
    private Vector3 originalPosition;
    public int cloneDeaths;
    
    void Start()
    {
        originalPosition = transform.position;
        cloneDeaths = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            // take clone to original position
            cloneDeaths++;
            transform.position = originalPosition;
        }
    }
 
}