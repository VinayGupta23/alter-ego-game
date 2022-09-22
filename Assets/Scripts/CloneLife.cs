using UnityEngine;

public class CloneLife : MonoBehaviour
{
    private Vector3 originalPosition;
    
    void Start()
    {
        originalPosition = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            // take clone to original position
            Analytics.RecordCloneDeath();
            transform.position = originalPosition;
        }
    }
 
}