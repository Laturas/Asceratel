using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    private bool paused;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;

    void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Settings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (paused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
}
