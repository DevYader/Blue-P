using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Basic Attributes")]
    public float movementSpeed = 3f;
    private CharacterController charCon;
    private InputAction moveAction;

    private Camera mainCamera;

    private bool isEverythinInit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        mainCamera = GetComponentInChildren<Camera>();

        if(charCon != null && moveAction != null && mainCamera != null)
        {
            isEverythinInit = true;
        }
        else
        {
            isEverythinInit = false;
            Debug.LogError("Not every component is initialized inside the Player Controller.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(isEverythinInit)
        {
            Vector2 moveInput = moveAction.ReadValue<Vector2>();

            Vector3 move = mainCamera.transform.forward * moveInput.y + mainCamera.transform.right * moveInput.x;
            move *= movementSpeed * Time.deltaTime;

            charCon.Move(move);
        }
    }
}
