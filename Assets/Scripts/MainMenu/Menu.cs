using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenu;
    public GameObject MenuMenu;

    // New variable for the cooldown
    private float nextPressTime = 0;
    private float cooldown = 0.5f; // 0.5 seconds cooldown, adjust as necessary

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.time > nextPressTime)
        {
            nextPressTime = Time.time + cooldown;

            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void SwitchToMainMenu()
    {
        Time.timeScale = 1;
        Paused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        MenuMenu.SetActive(false);
        Paused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        MenuMenu.SetActive(true);
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        Paused = true;
    }
}
