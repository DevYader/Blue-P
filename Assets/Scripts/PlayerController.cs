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
    [Header("Components")]
    [SerializeField]
    private GameObject grabPoint;

    private GameObject cameraParent;

    private bool isEverythingInIt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        mainCamera = GetComponentInChildren<Camera>();
        cameraParent = GetComponentInChildren<CameraController>().gameObject;

        if(charCon != null && moveAction != null && mainCamera != null)
        {
            isEverythingInIt = true;
        }
        else
        {
            isEverythingInIt = false;
            Debug.LogError("Not every component is initialized inside the Player Controller.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
        // Detects items in front of the player's camera

        RaycastHit hit;
        Vector3 origin = cameraParent.transform.position;
        Vector3 direction = mainCamera.transform.forward;
        LayerMask layerMask = LayerMask.GetMask("Item");

        if(Physics.Raycast(origin, direction, out hit, 10f, layerMask))
        {
            Item item = hit.transform.gameObject.GetComponent<Item>();

            if(item != null)
            {
                item.target = grabPoint;
                item.rigidBody.useGravity = false;
                item.isGrabbed = true;
            }
        }
    }

    private void Movement()
    {
        if(isEverythingInIt)
        {
            Vector2 moveInput = moveAction.ReadValue<Vector2>();

            Vector3 move = cameraParent.transform.forward * moveInput.y + mainCamera.transform.right * moveInput.x;
            move *= movementSpeed * Time.deltaTime;

            charCon.Move(move);
        }
    }

    
}
