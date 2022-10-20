using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlertManager : MonoBehaviour
{
    public float visibleDuration = 2f;

    TextMeshProUGUI popupText;
    float elapsedTime = 0f;
    bool isShowing = false;

    // Start is called before the first frame update
    void Start()
    {
        popupText = GetComponent<TextMeshProUGUI>();
        popupText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= visibleDuration)
            {
                popupText.text = "";
                isShowing = false;
            }
        }
    }

    public void ShowText(string text)
    {
        popupText.text = text;
        isShowing = true;
        elapsedTime = 0f;
    }
}
