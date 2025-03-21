using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelName);
        Invoke(nameof(ResetPlayerControls), 0.5f); // wait for scene load, then reset controls
    }

    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex + 1 < SceneManager.sceneCountInBuildSettings) //ensure next level exists
        {
            SceneManager.LoadScene(currentIndex + 1);
            Time.timeScale = 1f; // unpause game when loading
            Invoke(nameof(ResetPlayerControls), 0.5f);
        }
        else
        {
            Debug.Log(" No more levels. Returning to Main Menu.");
            LoadMainMenu();
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Invoke(nameof(ResetPlayerControls), 0.5f);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log(" Quitting Game.");
        Application.Quit();
    }

    private void ResetPlayerControls()
    {
        Debug.Log(" Resetting Player Controls...");

        // Enable Player Movement
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerMovement player = playerObject.GetComponent<playerMovement>();
            if (player != null)
            {
                player.enabled = true;
                Debug.Log("Player movement enabled.");
            }
        }

        // Enable Mouse Look
        GameObject cameraObject = GameObject.FindWithTag("MainCamera");
        if (cameraObject != null)
        {
            MonoBehaviour cameraControl = cameraObject.GetComponent<MonoBehaviour>();
            if (cameraControl != null)
            {
                cameraControl.enabled = true;
                Debug.Log($"Camera control script ({cameraControl.GetType().Name}) enabled.");
            }
        }

        // Reset Timer (Fixed)
        GameTimer timer = FindObjectOfType<GameTimer>();
        if (timer != null)
        {
            timer.ResetTimer();
            Debug.Log("Timer reset.");
        }

        // Lock cursor again for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
