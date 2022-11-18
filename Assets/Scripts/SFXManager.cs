using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip ButtonClick;
    public AudioClip Click;
    public AudioClip Death;
    public AudioClip CloneDeath;
    public AudioClip Gem;
    public AudioClip PillStart;
    public AudioClip PillEnd;
    public AudioClip Respawn;
    public AudioClip TileBreak;
    public AudioClip Goal;

    public static SFXManager SFXInstance;
    
    private void Awake(){
        if (SFXInstance != null && SFXInstance != this ){
            Destroy(this.gameObject);
            return;

        }

        SFXInstance = this;
        DontDestroyOnLoad(this);
        
    }


}
