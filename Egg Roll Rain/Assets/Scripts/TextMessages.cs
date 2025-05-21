using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextMessages : MonoBehaviour
{
    public Camera PlayerCamera;

    public GameObject InteractButton;
    public GameObject TextBox;
    public GameObject TextManager;
    public GameObject Letter;
    public GameObject AngryFaceIcon;
    public LayerMask InteractLayer;
    public bool Interacted;
    

    // Start is called before the first frame update
    void Start()
    {
        AngryFaceIcon.SetActive(false);
        Letter.SetActive(false);
        Interacted = false;
        TextBox.SetActive(false);
        InteractButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = 100f;
        MousePos = PlayerCamera.ScreenToWorldPoint(MousePos);

        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if ((Physics.Raycast(ray, out hit, 5f, InteractLayer))&&(Interacted==false))
        {
            if (hit.transform.name == "RayHitObj")
            {
                InteractButton.SetActive(true);
                if (Input.GetKeyDown("e"))
                {
                    Interacted=true;
                    TextBox.SetActive(true);
                    PlayDialogues();
                    
                }
            }
            else
            {
                InteractButton.SetActive(false);
            }
        }
        else
        {            
            InteractButton.SetActive(false);
        }

        
        
    }

    void PlayDialogues()
    {
        StartCoroutine(PauseTime(5f));

    }

    IEnumerator PauseTime(float duration)
    {
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Hey There!, I was waiting for you", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Wait, Who are you?", 5f);
        yield return new WaitForSeconds(duration); 
        AngryFaceIcon.SetActive(true);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "You don't know me??", 5f);
        yield return new WaitForSeconds(duration);
        AngryFaceIcon.SetActive(false);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "I am the EggLord, the king of all eggs and your egg fantasies", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "How did I get here and what do you want??", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "I used my powers to call you here, you are selected for the greatest opportunity anyone can get", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Tell me quick, I don't have time, I have to level up my chickens in egg simulator", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Fine, I will give you this letter, you deliever it to my beloved $%@^@* ,Make sure it doesn't break or get stolen, it's valuable", 5f);
        Letter.SetActive(true);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "If you can call me like that, why can't you just use your powers and do that as well??", 5f);
        yield return new WaitForSeconds(duration);
        AngryFaceIcon.SetActive(true);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "I SAID JUST DO IT!", 5f);
        yield return new WaitForSeconds(duration);
        AngryFaceIcon.SetActive(false);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", ".", 1.5f);
        yield return new WaitForSeconds(1.5f);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "..", 1.5f);
        yield return new WaitForSeconds(1.5f);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "...", 1.5f);
        yield return new WaitForSeconds(1.5f);
        Letter.SetActive(false);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Fine. Let's start...", 5f);
        yield return new WaitForSeconds(duration);
        FindObjectOfType<SceneLoader>().LoadNextLevel();

    }
}
