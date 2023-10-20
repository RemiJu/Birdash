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
    public int highScore;
    
      
    public static Toolbox instance;
    public NewTarget newTarget;
    public TMP_Text highScoreText;




    private void Awake()
    {
        MakeSingleton();
       
        highScore = 0;

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

            if (score > highScore)
            {
                //SetNewHighScore();
                //Debug.Log("New High Score is: " + highScore);
            }


            if (Input.GetKey(KeyCode.F4))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }

    }

    /// SCORE----------------------------------------------------SCORE

    public void SetNewHighScore() { 
    
        highScore = score;
        

    }

    public void SetHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore;
    }


    /// OTHER----------------------------------------------------OTHER
    public void DeleteToolBox()
    {
        Destroy(this);
    }

   
}
