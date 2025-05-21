using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownTeleport : MonoBehaviour
{
    public Vector3 TeleportPos;
    public CharacterController Controller;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= -25f)
        {
            Debug.Log("FELL DOWN");
            Controller.enabled = false;
            gameObject.transform.position = TeleportPos;
            Controller.enabled = true;
            FindAnyObjectByType<Dialogue>().PushDialogue("Player", "AAAAAAAAA!", 3f);
        }
    }
}
