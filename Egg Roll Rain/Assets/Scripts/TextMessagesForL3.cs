using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessagesForL3 : MonoBehaviour
{
    public Camera PlayerCamera;

    public GameObject InteractButton;
    public GameObject TextBox;
    public GameObject TextManager;
    public GameObject OmeletteMaker;
    public GameObject LevelCompleteGate;
    public LayerMask InteractLayer;
    public LayerMask TeleportLayer;
    public bool Interacted;
    bool LevelCompleted;

    // Start is called before the first frame update
    void Start()
    {
        LevelCompleteGate.SetActive(false);
        OmeletteMaker.SetActive(false);
        LevelCompleted = false;
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

        if ((Physics.Raycast(ray, out hit, 5f, InteractLayer)) && (Interacted == false))
        {
            if (hit.transform.name == "RayHitObj")
            {
                InteractButton.SetActive(true);
                if (Input.GetKeyDown("e"))
                {
                    Interacted = true;
                    TextBox.SetActive(true);
                    PlayDialogues();

                }
            }
            else
            {
                InteractButton.SetActive(false);
            }
        }
        else if (Physics.Raycast(ray, out hit, 2f, TeleportLayer) && (!LevelCompleted))
        {
            FindObjectOfType<SceneLoader>().LoadNextLevel();
            LevelCompleted = true;
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
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Traveller, what are you doing?!", 4f);
        yield return new WaitForSeconds(4);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Um EggLord has asked me to give a letter to his beloved Egqueen-", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Egqueen is a witch, she casts spells, they both want to take over the world", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "You are just helping them complete the ritual by giving this spell", 3f);
        yield return new WaitForSeconds(3);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "How do you know?? WHat should I do??", 3f);
        yield return new WaitForSeconds(3);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "My information source is not important", 4f);
        yield return new WaitForSeconds(4);
        OmeletteMaker.SetActive(true);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Take this omelette maker, and omelettize them as soon as you see them both.", 5f);
        yield return new WaitForSeconds(5);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Um... thanks...", 3f);
        yield return new WaitForSeconds(3);
        OmeletteMaker.SetActive(false);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Goodluck on the journey, don't believe anyone or whatever they say", 5f);
        yield return new WaitForSeconds(5);
        LevelCompleteGate.SetActive(true);
    }
}
