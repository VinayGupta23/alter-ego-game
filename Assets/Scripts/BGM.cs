using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM BGMInstance;

    private void Awake(){
        if (BGMInstance != null && BGMInstance != this ){
            Destroy(this.gameObject);
            return;

        }

        BGMInstance = this;
        DontDestroyOnLoad(this);
        
    }

}
