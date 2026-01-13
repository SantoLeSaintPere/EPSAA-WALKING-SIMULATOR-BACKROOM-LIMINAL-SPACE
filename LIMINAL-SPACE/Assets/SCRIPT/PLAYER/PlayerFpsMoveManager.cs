using System;
using UnityEngine;

public class PlayerFpsMoveManager : MonoBehaviour
{
    CharacterController characterController;
    PlayerFpsInputReader inputReader;



    public float speed;

    Vector3 newDir;
    [HideInInspector]
    public float xValue, yValue;
    //[HideInInspector]
    public float rotSPeed = 1;
    [Header("LOOK SET UP")]
    public int xlimitDOWN = 30;
    [Range(15, 60)]
    public int xlimitUP = 20;

    public Transform holder;
    public float jumpHeight = 3f;
    public float gravity = -19.81f;
    Vector3 velocity;

    public bool isGrounded, freezeMove;

    public float stepTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputReader = GetComponent<PlayerFpsInputReader>();


    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = characterController.isGrounded;
        FreeRotMove();
        CalculateDir();
        CalculateGravity();

        if (!freezeMove)
        {
            characterController.Move(newDir * speed * Time.deltaTime);
            characterController.Move(velocity * Time.deltaTime);
        }


    }

    private void CalculateGravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        if (inputReader.inputControls.PLAYER.JUMP.WasPerformedThisFrame() && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

    }

    protected void CalculateDir()
    {
        newDir = inputReader.direction;
        newDir = newDir.x * transform.right.normalized + newDir.z * transform.forward.normalized;
        newDir.y = 0f;
    }

    private void FreeRotMove()
    {
        xValue += (inputReader.lookX * rotSPeed * 100) * Time.deltaTime;
        xValue = Mathf.Clamp(xValue, -xlimitDOWN, xlimitUP);
        yValue += (inputReader.lookY * rotSPeed * 100) * Time.deltaTime;

        Quaternion rot = Quaternion.Euler(0, yValue, 0);
        transform.rotation = rot;


        Quaternion rot2 = Quaternion.Euler(-xValue, 0, 0);
        holder.localRotation = rot2;

    }
}