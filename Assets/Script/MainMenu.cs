using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        PauseMenu.isPause = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
