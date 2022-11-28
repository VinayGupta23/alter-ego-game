using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    // Start is called before the first frame update
    Camera currentCamera;
    float currentSize;
    
    float startSize;
    float targetSize;
    [SerializeField]
    float zoomSpeed = 0.25f;
    float elapsedTime;

    void Start()
    {
        currentCamera = gameObject.GetComponent<Camera>();
        currentSize = targetSize = currentCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSize != targetSize)
        {
            elapsedTime += Time.deltaTime * zoomSpeed;
            currentSize = Mathf.SmoothStep(startSize, targetSize, elapsedTime);
            currentCamera.orthographicSize = currentSize;
        }
    }

    public void PerformZoom(float delta = 2f)
    {
        elapsedTime = 0;
        startSize = currentSize;
        targetSize = currentSize + delta;
    }
}
