using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private float rotationX = 0f;

    public Transform cameraTransform;
    private bool canMove = true; //player can move or not

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // cursor in the center
    }

    void Update()
    {
        if (!canMove) return; // stop movement when disabled
        // A, D
        float moveX = Input.GetAxis("Horizontal");
        // W, S 
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        //gravity
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -2f;
        }
        controller.Move(velocity * Time.deltaTime);

        //mouse controls
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate player
        transform.Rotate(Vector3.up * mouseX);

        // Vertical rotation
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Prevent flipping
        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }
        else
        {
            Debug.LogError("🚨 CameraTransform is not assigned in Inspector!");
        }
    }

    public void SetMovement(bool state)
    {
        canMove = state;
    }
}
