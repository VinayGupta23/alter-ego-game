using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTrigger : MonoBehaviour
{
    ZoomOut zoomHandler;
    [SerializeField]
    float zoomDelta = 2f;

    // Start is called before the first frame update
    void Start()
    {
        zoomHandler = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ZoomOut>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zoomHandler.PerformZoom(zoomDelta);
            Destroy(this);
        }
    }
}
