using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.ProBuilder.MeshOperations;

//Manager class for pausing the app
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen; // User Interface (UI) elements shown on pause
    [SerializeField] GameObject helpScreen;
    [SerializeField] CinemachineBrain cinemachineBrain; // Controls the camera behaviour of the player
    bool onPause = false;
    float timeScaleBeforePause = 1f;

    bool cursorWasVisible;
    CursorLockMode cursorWasLocked;

    // Start is called before the first frame update
    void Start()
    {
        onPause = false;
        timeScaleBeforePause = Time.timeScale; //store value

        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // When F2 button pressed, toggle between Pause and Unpause (Resume)
        if (Input.GetKeyUp(KeyCode.F2))
        {
            if (!onPause)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
        else if (Input.GetKeyUp(KeyCode.F1)) { 
            if (!onPause)
            {
                ShowHint();
            }
            else
            {
                DisableHint();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("MainMenuScene");
            cursorWasVisible = Cursor.visible;
            cursorWasLocked = Cursor.lockState;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Pauses the app by freezing the time scale 
    void Pause()
    {
        onPause = true;
        cursorWasVisible = Cursor.visible;
        cursorWasLocked = Cursor.lockState;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseScreen.SetActive(onPause);
        cinemachineBrain.enabled = !onPause;
        timeScaleBeforePause = Time.timeScale;
        Time.timeScale = 0f;
    }

    void ShowHint()
    {
        onPause = true;
        cursorWasVisible = Cursor.visible;
        cursorWasLocked = Cursor.lockState;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        helpScreen.SetActive(onPause);
        cinemachineBrain.enabled = !onPause;
        timeScaleBeforePause = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        onPause = false;
        Cursor.visible = cursorWasVisible;
        Cursor.lockState = cursorWasLocked;
        pauseScreen.SetActive(onPause);
        cinemachineBrain.enabled = !onPause; 
        Time.timeScale = timeScaleBeforePause;
        Debug.Log("Unpausing...");
    }

    public void DisableHint()
    {
        onPause = false;
        Cursor.visible = cursorWasVisible;
        Cursor.lockState = cursorWasLocked;
        helpScreen.SetActive(onPause);
        cinemachineBrain.enabled = !onPause;
        Time.timeScale = timeScaleBeforePause;
        Debug.Log("Unpausing...");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting...");
    }

    public void RestartGame()
    {
        ScoreManager.scorevalue = 0;
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("ElementLand");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
