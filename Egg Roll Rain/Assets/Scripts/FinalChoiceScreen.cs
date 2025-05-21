using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChoiceScreen : MonoBehaviour
{
    public GameObject ChoiceSprite;
    public GameObject Choice1;
    public GameObject Choice2;
    float Choice;

    // Start is called before the first frame update
    void Start()
    {
        ChoiceSprite.SetActive(true);
        Choice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Choice == 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Choice = 1;
                Choice1.SetActive(true);
                ChoiceSprite.SetActive(false);
            }
            else if (Input.GetKeyDown("f")) 
            { 
                Choice = 2;
                Choice2.SetActive(true);
                ChoiceSprite.SetActive(false);
            }

        }

    }
}
