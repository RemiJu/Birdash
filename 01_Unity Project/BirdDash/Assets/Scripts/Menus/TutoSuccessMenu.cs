using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoSuccessMenu : MonoBehaviour
{
    public GameObject successMenu;


    public SoundManager soundManager;

    private void Awake()
    {

        successMenu.SetActive(false);
    }


    public void SuccessGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        soundManager.Delivered();
        successMenu.SetActive(true);
        Time.timeScale = 0;





    }

    public void NextGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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
