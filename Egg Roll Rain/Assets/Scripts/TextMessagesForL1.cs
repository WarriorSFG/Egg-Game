using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextMessagesForL1 : MonoBehaviour
{
    [SerializeField] Animator TransitionAnim;


    public LayerMask DigSiteMask;

    public Camera PlayerCamera;

    public GameObject TextManager;
    public GameObject InteractButton;
    public GameObject Shovel;
    public GameObject DigSites;
    public GameObject FinishLevel;

    public LayerMask InteractLayer;

    public bool Interacted;
    public bool HasShovel;
    public bool HasKey;

    bool LevelComplete;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMapAnim());
        Interacted = false;
        HasShovel = false;
        LevelComplete = false;

        DigSites.SetActive(false);
        InteractButton.SetActive(false);
        Shovel.SetActive(false);
        FinishLevel.SetActive(false);
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
            if (HasShovel == false)
            {
                if ((Physics.Raycast(ray, out hit, 5f, InteractLayer)))
                {
                    if (hit.transform.name == "ShovelHitObj")
                    {
                        if (Input.GetKeyDown("e"))
                        {
                            HasShovel = true;
                            DigSites.SetActive(true);
                            Shovel.SetActive(false);

                        }
                    }

                }
            }
            else
            {
                if ((Physics.Raycast(ray, out hit, 5f, DigSiteMask)))
                {
                    if (hit.transform.name == "CorrectDigSite")
                    {
                        if (Input.GetKeyDown("e"))
                        {
                            TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "GREAT! Now come back,I'll let you pass", 4f);
                            HasKey = true;
                            hit.transform.gameObject.SetActive(false);
                        }                        
                    }
                    else
                    {
                        if (Input.GetKeyDown("e"))
                        {
                            TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Nothing here!", 2f);
                            hit.transform.gameObject.SetActive(false);
                            FinishLevel.SetActive(true);
                        }
                    }

                    if((hit.transform.name == "Finish Level")&&(LevelComplete==false))
                    {
                        FindAnyObjectByType<SceneLoader>().LoadNextLevel();
                        LevelComplete = true;
                    }

                }
            
            }
        }

        
        

    }
    
    IEnumerator LoadMapAnim()
    {
        yield return new WaitForSeconds(4f);
        TransitionAnim.SetTrigger("MapClose");

    }
    void PlayDialogues()
    {
        StartCoroutine(PauseTime(5f));

    }

    IEnumerator PauseTime(float duration)
    {
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Hey stop, you can't go any further than this", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "why not?", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "You look like an intruder", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Egg Lord gave me a task to give a letter to egqueen, I'll tell him", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "NOOOO!", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Actually I lost my key to this door somewhere in the egchanted forest", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "So what now?", 5f);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("EggLord", "Take my shovel, go search and bring it", 5f);
        Shovel.SetActive(true);
        yield return new WaitForSeconds(duration);
        TextManager.GetComponent<Dialogue>().PushDialogue("Player", "Fine, be right back.", 5f);
        yield return new WaitForSeconds(duration);
        
    }
}
