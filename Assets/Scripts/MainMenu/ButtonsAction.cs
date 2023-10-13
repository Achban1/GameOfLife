using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsAction : MonoBehaviour


{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameOfLife");
    }

    public void MainMenue()
    {
        SceneManager.LoadScene("MainMenue");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

