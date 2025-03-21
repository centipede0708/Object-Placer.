using UnityEngine;
using TMPro;
using System.Collections;

public class InvisibleWallTrigger : MonoBehaviour
{
    public GameObject warningPanel; // Assign Warning Panel in Inspector
    public TMP_Text warningText; // Assign TextMeshPro Warning Text
    public GameObject loseScreen; // Assign Lose Screen Panel

    private bool isPlayerOutside = false;
    private float timer = 10f; // Countdown time

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOutside = true;
            warningPanel.SetActive(true);
            StartCoroutine(StartCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOutside = false;
            warningPanel.SetActive(false); // Hide warning panel
            StopCoroutine(StartCountdown()); // Stop the countdown
        }
    }

    private IEnumerator StartCountdown()
{
    float timeLeft = timer;
    while (timeLeft > 0 && isPlayerOutside)
    {
        warningText.text = $"Complete the work first!! Return to play area or you will lose in {Mathf.Ceil(timeLeft)}s";
        yield return new WaitForSeconds(1f);
        timeLeft--;
    }

    if (isPlayerOutside)
    {   // when player is outside
        loseScreen.SetActive(true); 
        warningPanel.SetActive(false); 
        Time.timeScale = 0; 

        // Disable player movement script 
        playerMovement playerMovement = FindObjectOfType<playerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // Unlock cursor for UI interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}




    private void DisableCameraControls()
{
    Debug.Log("🔎 Disabling camera control scripts...");

    MonoBehaviour[] allScripts = FindObjectsOfType<MonoBehaviour>();

    foreach (MonoBehaviour script in allScripts)
    {
        string scriptName = script.GetType().Name.ToLower();

        if (scriptName.Contains("camera") || scriptName.Contains("look") || scriptName.Contains("mouse") || script is playerMovement)
        {
            script.enabled = false;
            Debug.Log($"✅ Disabled script: {script.GetType().Name}");
        }
    }
}

}
