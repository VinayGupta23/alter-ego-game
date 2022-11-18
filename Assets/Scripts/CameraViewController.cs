using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewController : MonoBehaviour
{
    // Start is called before the first frame update
    public float sceneWidth = 40;

    Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update()
    {
        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.6f * unitsPerPixel * Screen.height;
        //Debug.Log(Screen.height + " " + Screen.width + " " + desiredHalfHeight);
        _camera.orthographicSize = desiredHalfHeight;
    }
}
