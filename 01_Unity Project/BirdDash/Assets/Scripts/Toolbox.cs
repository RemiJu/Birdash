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

    }

    /// SCORE----------------------------------------------------SCORE

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
