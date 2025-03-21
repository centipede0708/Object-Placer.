using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Transform playerCamera;
    public Transform holdPosition;
    public float pickupRange = 3f;
    public float rotationSpeed = 100f;

    private Rigidbody heldObject;
    private bool placingMode = false;
    private playerMovement playerMovement;
    private Color originalColor;
    private bool isInDropZone = false;

    void Start()
    {
        playerMovement = FindObjectOfType<playerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            if (heldObject == null)
                TryPickupObject();
            else if (!placingMode)
                EnterPlacingMode();
            else
                DropObject();
        }

        // Rotate object while placing
        if (placingMode && heldObject != null)
        {
            if (Input.GetKey(KeyCode.A))
                heldObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
            if (Input.GetKey(KeyCode.D))
                heldObject.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    void TryPickupObject()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position + transform.forward * 2f, 1f);

        foreach (Collider col in objectsInRange)
        {
            if (col.CompareTag("Pickup"))
            {
                heldObject = col.GetComponent<Rigidbody>();

                if (heldObject != null)
                {
                    heldObject.useGravity = false;
                    heldObject.isKinematic = true;
                    heldObject.transform.position = holdPosition.position;
                    heldObject.transform.parent = holdPosition;
                    placingMode = false;

                    Renderer objRenderer = heldObject.GetComponent<Renderer>();
                    if (objRenderer != null)
                    {
                        originalColor = objRenderer.material.color;
                        Debug.Log(" Original color stored: " + originalColor);
                    }
                    else
                    {
                        Debug.LogError("Renderer not found on object: " + col.name);
                    }

                    return;
                }
            }
        }
    }

    void EnterPlacingMode()
    {
        if (heldObject != null)
        {
            placingMode = true;
            heldObject.transform.parent = null;
            heldObject.useGravity = false;
            heldObject.isKinematic = true;
            playerMovement.SetMovement(false);
            Debug.Log("🔄 Entered placing mode.");
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            placingMode = false;
            heldObject.useGravity = true;
            heldObject.isKinematic = false;
            heldObject.transform.parent = null;

            // Reset color when dropped
            FindObjectOfType<DropZone>().ResetColor(heldObject.gameObject);

            heldObject = null;
            playerMovement.SetMovement(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (placingMode && heldObject != null && other.CompareTag("DropZone"))
        {
            isInDropZone = true;
            ChangeObjectColor(Color.green);
            Debug.Log(" Object entered DropZone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (placingMode && heldObject != null && other.CompareTag("DropZone"))
        {
            isInDropZone = false;
            ChangeObjectColor(Color.red);
            Debug.Log("Object exited DropZone.");
        }
    }

    void ChangeObjectColor(Color color)
    {
        if (placingMode && heldObject != null)
        {
            Renderer objRenderer = heldObject.GetComponent<Renderer>();
            if (objRenderer != null)
            {
                objRenderer.material.color = color;
                Debug.Log("Object color changed to: " + color);
            }
            else
            {
                Debug.LogError(" Renderer not found on held object!");
            }
        }
    }

    public bool IsPlacingMode()
    {
        return placingMode;
    }
}
