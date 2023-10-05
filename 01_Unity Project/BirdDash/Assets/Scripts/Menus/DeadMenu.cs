using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DeadMenu : MonoBehaviour
{
    public GameObject deadMenu;
    public TMP_Text scoreText;
    public TMP_Text timerText;

    public NewTarget newTarget;
    public Timer timer;

    private void Awake()
    {
        deadMenu.SetActive(false);
    }

   
    public void endGame()
    {
        deadMenu.SetActive(true);
        Time.timeScale = 0;

        scoreText.text = "Final Score: " + newTarget.score;
        timerText.text = "Final Time: " + timer.timer;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

