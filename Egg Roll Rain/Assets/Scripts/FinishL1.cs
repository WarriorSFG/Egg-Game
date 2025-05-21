using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishL1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.name == "Player")
        {
            Debug.Log("LoadNextLevel");
            FindAnyObjectByType<SceneLoader>().LoadNextLevel();
        }
    }
}
