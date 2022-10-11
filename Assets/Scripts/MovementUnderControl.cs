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

    public GameObject connector;

    private int index;

    public void Start()
    {
        //if (positions.Length > 1)
        //{
        //    LineRenderer lineRenderer = new GameObject().AddComponent<LineRenderer>();
        //    lineRenderer.startWidth = 0.4f;
        //    lineRenderer.endWidth = 0.4f;
        //    lineRenderer.material.color = Color.cyan;
        //    lineRenderer.positionCount = positions.Length + 1;
        //    lineRenderer.useWorldSpace = true;
        //    lineRenderer.SetPositions(positions);
        //    lineRenderer.SetPosition(positions.Length, positions[0]);
        //}

        if (connector != null)
        {
            if (positions.Length == 2)
            {
                connector = GameObject.Instantiate(connector);
                connector.transform.position = new Vector3(
                    (positions[0].x + positions[1].x) / 2,
                    (positions[0].y + positions[1].y) / 2,
                    0
                );

                if (Mathf.Abs(positions[1].x - positions[0].x) < 0.5)
                {
                    // Vertical connector
                    connector.transform.localScale = new Vector3(0.4f, positions[1].y - positions[0].y, 1);
                }
                else if (Mathf.Abs(positions[1].y - positions[0].y) < 0.5)
                {
                    // Horizontal connector
                    connector.transform.localScale = new Vector3(positions[1].x - positions[0].x, 0.4f, 1);
                }
                else
                {
                    Debug.LogWarning("Can only draw connector for horizontal or vertical movement.");
                    Destroy(connector);
                }
            }
            else
            {
                Debug.LogWarning("Can only draw connector between 2 points.");
            }
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
