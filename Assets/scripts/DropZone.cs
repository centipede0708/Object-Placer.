using UnityEngine;
using System.Collections.Generic;
using TMPro.Examples;

public class DropZone : MonoBehaviour
{
    public GameObject completionScreen; // Assign the UI panel in Inspector
    public int totalObjectsToPlace = 5; // Set the total number of objects to be placed correctly

    private Dictionary<GameObject, Color> originalColors = new Dictionary<GameObject, Color>(); // Store original colors
    private HashSet<GameObject> correctlyPlacedObjects = new HashSet<GameObject>(); // Track correctly placed objects
    private Collider dropZoneCollider; // Reference to this trigger collider

    private void Start()
    {
        dropZoneCollider = GetComponent<Collider>();
        if (completionScreen != null)
        {
            completionScreen.SetActive(false); // Hide the completion screen at the start
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")) 
        {
            Renderer objRenderer = other.GetComponent<Renderer>();
            if (objRenderer != null)
            {
                if (!originalColors.ContainsKey(other.gameObject))
                {
                    originalColors[other.gameObject] = objRenderer.material.color;
                }

                CheckAndUpdateColor(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickup")) 
        {
            correctlyPlacedObjects.Remove(other.gameObject);
            CheckAndUpdateColor(other.gameObject);
        }
    }

    private void CheckAndUpdateColor(GameObject obj)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        Collider objCollider = obj.GetComponent<Collider>();

        if (objRenderer != null && objCollider != null)
        {
            if (IsFullyInside(objCollider))
            {
                objRenderer.material.color = Color.green; // green only if fully inside
                correctlyPlacedObjects.Add(obj);
            }
            else
            {
                objRenderer.material.color = Color.red; //Stay red if even a part is outside
                correctlyPlacedObjects.Remove(obj);
            }
        }

        CheckCompletion();
    }

    private bool IsFullyInside(Collider objCollider)
    {
        Bounds objBounds = objCollider.bounds;
        Bounds zoneBounds = dropZoneCollider.bounds;

        return zoneBounds.Contains(objBounds.min) && zoneBounds.Contains(objBounds.max);
    }

    private void CheckCompletion()
    {
        if (correctlyPlacedObjects.Count == totalObjectsToPlace)
        {
            ShowCompletionScreen();
        }
    }

    private void ShowCompletionScreen()
{
    if (completionScreen != null)
    {
        completionScreen.SetActive(true);
        Time.timeScale = 0f; // Pause the game

        // Unlock cursor for UI interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Disable Player Movement
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerMovement player = playerObject.GetComponent<playerMovement>();
            if (player != null)
            {
                player.enabled = false;
            }
        }

        // Disable Camera Controls
        DisableCameraControls();
    }
}

private void DisableCameraControls()
{
    MonoBehaviour[] allScripts = FindObjectsOfType<MonoBehaviour>();

    foreach (MonoBehaviour script in allScripts)
    {
        string scriptName = script.GetType().Name.ToLower();

        if (scriptName.Contains("camera") || scriptName.Contains("look") || scriptName.Contains("mouse"))
        {
            script.enabled = false;
            Debug.Log($"Disabled camera control script: {script.GetType().Name}");
        }
    }
}


    // Call this when the object is dropped
    public void ResetColor(GameObject obj)
    {
        if (originalColors.ContainsKey(obj))
        {
            Renderer objRenderer = obj.GetComponent<Renderer>();
            if (objRenderer != null)
            {
                objRenderer.material.color = originalColors[obj]; // Restore original color
            }
            originalColors.Remove(obj);
        }
        correctlyPlacedObjects.Remove(obj);
    }
}
