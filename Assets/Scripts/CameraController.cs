using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Basic Attributes")]
    public float mouseSensitivity = 2f;
    private InputAction lookAction;
    private Vector3 pitch, yaw;
    private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        mainCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        pitch = Vector3.right; // rotates on the x axis
        yaw = Vector3.up; // rotates on the y axis

        Vector3 lookInput = lookAction.ReadValue<Vector2>();

        // horizontal rotation calc
        mainCamera.transform.eulerAngles += yaw * lookInput.x * mouseSensitivity * Time.deltaTime;

        //vertical rotation calc
        mainCamera.transform.eulerAngles -= pitch * lookInput.y * mouseSensitivity * Time.deltaTime;
        Mathf.Clamp(mainCamera.transform.eulerAngles.x, -90f, 90f);
    }
}
