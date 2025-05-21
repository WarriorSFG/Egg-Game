using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float MouseSensitivity;
    public float WalkSpeed;
    public float SprintBarSpeed;
    public float SprintBoost;
    public float SprintFOVIncrease;
    public float Gravity;
    public float JumpHeight;
    public float GroundDistance;

    public Color SprintBarColor;
    public Color CoolDownColor;

    public Camera PlayerCamera;

    public LayerMask GroundMask;
    public GameObject SprintPanel;
    public GameObject Torch;

    public Transform GroundCheck;

    float PlayerSpeed;
    float ForwardInput;
    float SidewaysInput;
    float VelocityVertical;

    float FOV; 

    float CamVerticalRotation;
    float CamHorizontalRotation;

    bool IsGrounded;
    bool AllowSprinting;
    bool TorchOn;

    CharacterController Controller;


    void Start()
    {
        Controller = GetComponent<CharacterController>();
        AllowSprinting = true;

        Torch.SetActive(false);

        FOV = PlayerCamera.fieldOfView;
        PlayerSpeed = WalkSpeed;

        //Locks the cursor in the middle
        Cursor.lockState = CursorLockMode.Locked;

        SprintPanel.GetComponent<Image>().color = SprintBarColor;

    }

    void Update()
    {
        //Move Player forwards and backwards

        ForwardInput = Input.GetAxis("Vertical");
        SidewaysInput = Input.GetAxis("Horizontal");

        Controller.Move(transform.right * SidewaysInput * Time.deltaTime * PlayerSpeed + transform.forward * ForwardInput * PlayerSpeed * Time.deltaTime);


        //Increase Speed on pressing Shift and change FOV

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if ((SprintPanel.transform.localScale.x > 0) &AllowSprinting)
            {
                SprintPanel.transform.localScale = new Vector3((SprintPanel.transform.localScale.x - SprintBarSpeed*Time.deltaTime), SprintPanel.transform.localScale.y, SprintPanel.transform.localScale.z);
                
                if (PlayerCamera.fieldOfView < (FOV + SprintFOVIncrease))
                {
                    PlayerCamera.fieldOfView += SprintFOVIncrease * 4f * Time.deltaTime;

                }

                if (PlayerSpeed < (WalkSpeed + SprintBoost))
                {
                    PlayerSpeed += SprintBoost * 4f * Time.deltaTime;
                }
            }
            else
            {
                AllowSprinting = false;
            }


            
        }

        if (!AllowSprinting)
        {
            SprintPanel.GetComponent<Image>().color = CoolDownColor;
            StartCoroutine(Sprint());
        }

        if((!Input.GetKey(KeyCode.LeftShift) || !AllowSprinting))  
        {
            if (SprintPanel.transform.localScale.x < 1)
            {
                SprintPanel.transform.localScale = new Vector3((SprintPanel.transform.localScale.x + SprintBarSpeed * Time.deltaTime), SprintPanel.transform.localScale.y, SprintPanel.transform.localScale.z);
            }

            if (PlayerCamera.fieldOfView > FOV) 
            {
                PlayerCamera.fieldOfView -= SprintFOVIncrease * 4f * Time.deltaTime;
            }

            if (PlayerSpeed > WalkSpeed)
            {
                PlayerSpeed -= SprintBoost * 4f * Time.deltaTime;
            }
            
        }


        //Jump Player on pressing spacebar

        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (Input.GetKey(KeyCode.Space) & IsGrounded)
        {
            VelocityVertical = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }


        Controller.Move(new Vector3(0, VelocityVertical * Time.deltaTime, 0));

        if (!IsGrounded)
        {
            VelocityVertical = VelocityVertical + Gravity*Time.deltaTime;
        }


        //Turn ON/OFF torch

        if (Input.GetKeyDown("f")) 
        {
            Torch.SetActive(!TorchOn);
            TorchOn = !TorchOn; 
        }
        
        

        //Rotate Camera based on mouse rotation

        CamHorizontalRotation += Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity;
        
        CamVerticalRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivity;
        CamVerticalRotation = Mathf.Clamp(CamVerticalRotation, -45, 45);

        PlayerCamera.transform.rotation = Quaternion.Euler(-CamVerticalRotation, CamHorizontalRotation, 0);

    }
    private void FixedUpdate()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0, CamHorizontalRotation, 0);
    }
    IEnumerator Sprint()
    {
        yield return new WaitForSeconds(2);
        AllowSprinting = true;
        SprintPanel.GetComponent<Image>().color = SprintBarColor;

    }

}
