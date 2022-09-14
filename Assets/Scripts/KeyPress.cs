using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPress : MonoBehaviour
{
    private DoorController door;

    // Start is called before the first frame update
    void Start()
    {
        if (name.StartsWith("Key"))
        {
            GameObject doorObject = GameObject.Find("Door" + name.Substring(3));
            if (doorObject)
            {
                door = doorObject.GetComponent<DoorController>();
                Debug.Log(string.Format("Door Manager: Paired {0} and {1}", name, door.name));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (door)
        {
            door.OpenDoor();
        }
    }
}
