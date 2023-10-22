using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;

    public void Play()
    {
        LevelSelect();
    }
    public void Tutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect() { 

        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    
    
    }

    public void Level1() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }

    public void Level2() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(5);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

}
