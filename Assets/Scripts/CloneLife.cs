using UnityEngine;

public class CloneLife : MonoBehaviour
{
    [SerializeField] private Transform clone;
    private Vector3 originalPosition;
    
    void Start()
    {
        originalPosition = clone.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            // take clone to original position
            clone.transform.position = originalPosition;
        }
    }
 
}