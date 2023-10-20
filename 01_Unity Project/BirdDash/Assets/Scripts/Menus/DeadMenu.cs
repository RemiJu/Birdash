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

    public Dialogue dialogue;
    public SoundManager soundManager;

    private void Awake()
    {
        toolbox = FindFirstObjectByType<Toolbox>();
        deadMenu.SetActive(false);
    }

   
    public void endGame()
    {
        //dialogue.textBox.SetActive(false);
        //dialogue.Customers[dialogue.currentLine].gameObject.SetActive(false);
        soundManager.GameOver();
        deadMenu.SetActive(true);
        Time.timeScale = 0;

        scoreText.text = "Final Score: " + newTarget.score;
        timerText.text = "Final Time: " + timer.timer;
       

        if (newTarget.score > toolbox.highScore)
        {
            toolbox.SetNewHighScore();
            newHighscore.SetActive(true);
            highScoreText.text = "High Score: " + toolbox.highScore;

        }
        else {
            failed.SetActive(true);
            highScoreText.text = "High Score: " + toolbox.highScore;

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

