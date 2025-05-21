using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI TextBox;
    public GameObject TextPanel;
    public GameObject PlayerIcon;
    public GameObject EggLordIcon;

    // Start is called before the first frame update
    void Start()
    {   
        PlayerIcon.SetActive(false);
        EggLordIcon.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushDialogue(string Speaker, string TextMessage, float Duration)
    {
        StartCoroutine(SendMessage(Speaker, TextMessage, Duration));
    }

    IEnumerator SendMessage(string Speaker, string TextMessage, float Duration)
    {
        TextPanel.SetActive(true);
        TextBox.text = TextMessage;

        if (Speaker == "EggLord") 
        {
            EggLordIcon.SetActive(true);
        }

        else if (Speaker == "Player")
        {
            PlayerIcon.SetActive(true);
        }
        

        yield return new WaitForSeconds(Duration);
        EggLordIcon.SetActive(false);
        PlayerIcon.SetActive(false);
        TextPanel.SetActive(false);

    }
}
