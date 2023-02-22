using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject blocker;
    [SerializeField] GameObject menuscreen;
    // Start is called before the first frame update


    void Start()
    {
        blocker.SetActive(false);
    }

    public void StartApp()
    {
        menuscreen.SetActive(false);
        blocker.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("ElementLand");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
