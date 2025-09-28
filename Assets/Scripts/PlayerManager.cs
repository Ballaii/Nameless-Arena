using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerManager playerManager;
    InputHandler inputHandler;
    Animator animator;
    CameraHandler cameraHandler;
    PlayerMovement playerMovement;
    [Header("Player Flags")]
    public bool isInteracting;
    public bool isSprinting;


    private void Awake()
    {
    }

    void Start()
    {
        cameraHandler = CameraHandler.singleton;

        playerManager = GetComponent<PlayerManager>();
        inputHandler = GetComponent<InputHandler>();
        animator = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        float delta = Time.deltaTime;
        isInteracting = animator.GetBool("isInteracting");


        playerManager.isSprinting = inputHandler.b_input;
        inputHandler.TickInput(delta);
        playerMovement.HandleMovement(delta);
        playerMovement.HandleRollingAndSprinting(delta);
    }

    private void FixedUpdate()
    {

        float delta = Time.fixedDeltaTime;

        if (cameraHandler != null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
        }
    }

    private void LateUpdate()
    {
        inputHandler.rollFlag = false;
        inputHandler.sprint = false;

        isSprinting = inputHandler.b_input;
    }
}
