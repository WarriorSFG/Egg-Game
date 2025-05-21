using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveIslands : MonoBehaviour
{
    Vector3 InitialPos;
    public Vector3 MoveSpeed;
    public Vector3 MoveRange;

    float Moved=0;
    bool SwitchDir = true;
    // Start is called before the first frame update
    void Start()
    {
        InitialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        
        if ((Moved > MoveRange.magnitude && SwitchDir) || (Moved < -MoveRange.magnitude && !SwitchDir))
        {
            SwitchDir =! SwitchDir;
        }
        else if(SwitchDir)
        {
            Moved += MoveSpeed.magnitude * Time.deltaTime;
            transform.position = InitialPos + MoveSpeed * Moved;
        }
        else if(!SwitchDir)
        {
            Moved -= MoveSpeed.magnitude * Time.deltaTime;
            transform.position = InitialPos + MoveSpeed * Moved;
        }

        
    }
}
