using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    bool HasSword1=false;
    bool HasSword2=false;  
    bool HasSword3=false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddSword(int SwordNumber)
    {
        switch(SwordNumber) {
            case 1:
                HasSword1 = true; 
                break;
            case 2:
                HasSword2 = true;
                break;
            case 3:
                HasSword3 = true;
                break;        
        }
    }
}
