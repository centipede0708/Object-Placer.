using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{   // 2-minute timer
    public float timeRemaining = 120f;
    private float startTime;
    public TextMeshProUGUI timerText;
    public GameObject completionScreen;

    private bool timerRunning = true;

    void Start()
    {
        startTime = timeRemaining;
        UpdateTimerUI();
        completionScreen.SetActive(false);
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                EndGame();
            }
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
{
    timerRunning = false;
    timeRemaining = 0;
    UpdateTimerUI();
    completionScreen.SetActive(true);
    Time.timeScale = 0f;

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
            player.enabled = false; // Disable movement
        }
    }

    // Disable Camera Control (Fix)
    DisableCameraControls();
}

private void DisableCameraControls()
{
    Debug.Log("🔎 Disabling camera control scripts...");

    MonoBehaviour[] allScripts = FindObjectsOfType<MonoBehaviour>();

    foreach (MonoBehaviour script in allScripts)
    {
        string scriptName = script.GetType().Name.ToLower();

        if (scriptName.Contains("camera") || scriptName.Contains("look") || scriptName.Contains("mouse"))
        {
            script.enabled = false;
            Debug.Log($"✅ Disabled camera script: {script.GetType().Name}");
        }
    }
}




    public void ResetTimer()
    {
        timeRemaining = startTime;
        timerRunning = true;
        UpdateTimerUI();
        Time.timeScale = 1f;
    }
}
