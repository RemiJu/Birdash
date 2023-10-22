using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class Toolbox : MonoBehaviour
{
    [Header("Variables")]
    public int score = 0;
    public int highScore_1;
    public int highScore_2;

    public static Toolbox instance;
    public NewTarget newTarget;
    public TMP_Text highScoreText;

    [Header("Music")]
    public AudioClip tutorial;
    public AudioClip level_1;
    public AudioClip level_2;
    public AudioClip MainMenu;
    public AudioSource audioSource;
    public bool lvl1;
    public bool lvl2;
    public bool tuto;
    public bool menu;



    private void Awake()
    {
        MakeSingleton();
       
        highScore_1 = 0;
        highScore_2 = 0;

    }


    
    void MakeSingleton()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 3)
        {


            if (newTarget == null)
            {
                newTarget = FindObjectOfType<NewTarget>();
            }
           
            score = newTarget.score;

           
            if (Input.GetKey(KeyCode.F4))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }

       StartBGmusic();

      
    }

    /// SCORE----------------------------------------------------SCORE


    public void StartBGmusic()
    {
        if (SceneManager.GetActiveScene().name == "Level 1" && !lvl1)
        {
            audioSource.Stop();
            audioSource.clip = level_1;
            audioSource.volume = 0.3f;
            audioSource.loop = true;
            audioSource.Play();
            lvl1 = true;
            lvl2 = false;
            tuto = false;
            menu = false;
            
        }
        if (SceneManager.GetActiveScene().name == "Level 2" && !lvl2)
        {
            audioSource.Stop();
            audioSource.clip = level_2;
            audioSource.volume = 0.3f;
            audioSource.loop = true;
            audioSource.Play();
            lvl1 = false;
            lvl2 = true;
            tuto = false;
            menu = false;
           

        }
        if ((SceneManager.GetActiveScene().name == "Tutorial A" || SceneManager.GetActiveScene().name == "Tutorial B" || SceneManager.GetActiveScene().name == "Tutorial C") && !tuto)
        {
            audioSource.Stop();
            audioSource.clip = tutorial;
            audioSource.volume = 0.3f;
            audioSource.loop = true;
            audioSource.Play();
            lvl1 = false;
            lvl2 = false;
            tuto = true;
            menu = false;
        }

        if (SceneManager.GetActiveScene().name == "MainMenu" && !menu)
        {
            audioSource.Stop();
            audioSource.clip = MainMenu;
            audioSource.volume = 0.3f;
            audioSource.loop = true;
            audioSource.Play();
            lvl1 = false;
            lvl2 = false;
            tuto = false;
            menu = true;

        }
    }


    public void SetNewHighScore() {

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            highScore_1 = score;
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            highScore_2 = score;
        }
        //highScore = score;
        

    }

    public void SetHighScoreText()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            highScoreText.text = "High Score: " + highScore_1;
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            highScoreText.text = "High Score: " + highScore_2;
        }
        //highScore = score;
        //highScoreText.text = "High Score: " + highScore;
    }


    /// OTHER----------------------------------------------------OTHER
    public void DeleteToolBox()
    {
        Destroy(this);
    }

   
}
