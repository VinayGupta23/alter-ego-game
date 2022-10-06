using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUnderControl : MonoBehaviour, IUnderControl
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3[] positions;


    [SerializeField]
    private bool allowMovement;

    private int index;

    public void Start()
    {
        if (positions.Length > 1) {
            LineRenderer lineRenderer = new GameObject().AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.4f;
            lineRenderer.endWidth = 0.4f;
            lineRenderer.material.color = Color.blue;
            lineRenderer.positionCount = positions.Length + 1;
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPositions(positions);
            lineRenderer.SetPosition(positions.Length, positions[0]);
        }


    }
    public bool IsActive {
        get { return allowMovement; }
    }

    public void Activate()
    {
        allowMovement = true;
    }

    public void Deactivate()
    {
        allowMovement = false;
    }

    public void Toggle()
    {
        if (allowMovement)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (allowMovement == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
            if (transform.position == positions[index])
            {
                if (index == positions.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
        }

       

    }
}
