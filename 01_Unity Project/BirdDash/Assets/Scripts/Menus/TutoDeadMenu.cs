using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoDeadMenu : MonoBehaviour
{
    public GameObject deadMenu;
   
      
    public SoundManager soundManager;

    private void Awake()
    {
        
        deadMenu.SetActive(false);
    }


    public void endGame()
    {
        
        soundManager.GameOver();
        deadMenu.SetActive(true);
        Time.timeScale = 0;

       


       
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
