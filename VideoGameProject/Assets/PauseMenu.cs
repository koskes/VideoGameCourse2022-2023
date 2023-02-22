using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

//Manager class for pausing the app
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen; // User Interface (UI) elements shown on pause
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
        // When Escape button pressed, toggle between Pause and Unpause (Resume)
        if (Input.GetKeyUp(KeyCode.Escape))
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
    }

    // Pauses the app by freezing the time scale 
    void Pause()
    {
        onPause = true;

        cursorWasVisible = Cursor.visible;
        cursorWasLocked = Cursor.lockState;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;


        // Show pause screen
        pauseScreen.SetActive(onPause);

        // ------- Disabling any extra behaviours ----------

        cinemachineBrain.enabled = !onPause; //disable camera control with mouse movement

        // L______

        // Set the speed that time passes to zero
        timeScaleBeforePause = Time.timeScale; //store value

        Time.timeScale = 0f;


        // Example: Time will run twice as fast with Time.timeScale = 2f;
    }

    // Pauses the app by unfreezing the time scale
    public void Unpause()
    {

        onPause = false;

        Cursor.visible = cursorWasVisible;
        Cursor.lockState = cursorWasLocked;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;


        // Hide pause screen
        pauseScreen.SetActive(onPause);

        // ------- Enabling any extra behaviours ----------

        cinemachineBrain.enabled = !onPause; //enable camera control with mouse movement

        // L______

        // Set the speed that time passes back to what it was before pause
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
}
