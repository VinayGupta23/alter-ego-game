using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformIndicatorUnderControl : MonoBehaviour, IUnderControl
{
    [SerializeField]
    private GameObject indicatorPrefab;
    private Color targetColor = Color.clear;

    bool isActive = false;
    bool colorChangeNeeded = false;

    public bool IsActive
    {
        get { return isActive; }
    }

    public void SetBaseColor(Color color)
    {
        targetColor = color;
        colorChangeNeeded = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (colorChangeNeeded)
        {
            float length = GetComponent<SpriteRenderer>().size.x;
            float offset = (length / 2) - 0.25f;

            Vector3 leftPoint = transform.position;
            leftPoint.x -= offset;

            Vector3 rightPoint = transform.position;
            rightPoint.x += offset;

            Vector3[] positions = { leftPoint, rightPoint };

            foreach (var position in positions)
            {
                GameObject indicator = GameObject.Instantiate(indicatorPrefab);
                indicator.transform.position = position;
                indicator.transform.parent = transform;
                indicator.GetComponent<SpriteRenderer>().color = targetColor;
            }
            
            colorChangeNeeded = false;
        }
    }

    public void Activate()
    {

    }

    public void Deactivate()
    {

    }

    public void Toggle()
    {

    }
}
