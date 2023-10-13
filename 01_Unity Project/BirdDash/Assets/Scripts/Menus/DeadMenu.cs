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
    public TMP_Text highScoreText;

    public NewTarget newTarget;
    public Toolbox toolbox;
    public Timer timer;

    public GameObject failed;
    public GameObject newHighscore;

    
    public SoundManager soundManager;

    private void Awake()
    {
        toolbox = FindFirstObjectByType<Toolbox>();
        deadMenu.SetActive(false);
    }

   
    public void endGame()
    {
        soundManager.GameOver();
        deadMenu.SetActive(true);
        Time.timeScale = 0;

        scoreText.text = "Final Score: " + newTarget.score;
        timerText.text = "Final Time: " + timer.timer;
        highScoreText.text = "High Score: " + toolbox.highScore;

        if (newTarget.score < toolbox.highScore)
        {
            failed.SetActive(true);
        }
        else { 
            newHighscore.SetActive(true);
        }
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

