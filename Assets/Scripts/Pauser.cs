using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    private bool paused;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject SensitivitySlider;

    void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        SensitivitySlider.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        SensitivitySlider.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
