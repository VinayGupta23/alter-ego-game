using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMenu()
    {
        LevelManager.Instance.MainMenu();
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Click);
    }
}
