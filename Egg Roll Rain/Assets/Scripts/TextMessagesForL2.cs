using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessagesForL2 : MonoBehaviour
{
    public Camera PlayerCamera;

    public GameObject InteractButton;
    public GameObject TextBox;
    public GameObject TextManager;
    public LayerMask InteractLayer;
    public LayerMask TeleportLayer;
    public bool Interacted;
    bool LevelCompleted;

    // Start is called before the first frame update
    void Start()
    {
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
        else if(Physics.Raycast(ray, out hit, 2f, TeleportLayer)&&(!LevelCompleted))
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
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Hello.", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Um Hi, could you tell me the way to Eggonia Fields?", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Yes, go straight, through the rocky islands, the path is waiting", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "While you go, think...", 3f);
        yield return new WaitForSeconds(3);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Think what??", 3f);
        yield return new WaitForSeconds(3);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Do you really think, what you are giving is just a letter and not a secret spell..?", 5f);
        yield return new WaitForSeconds(5);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Um... thanks for the way", 3f);
        yield return new WaitForSeconds(3);        
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Don't believe me, it's fine. You are welcome!", 3f);
        yield return new WaitForSeconds(3);
    }
}
