using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class NewTarget : MonoBehaviour
{
    public GameObject currentTarget;
    public Transform home;
    public bool atHome;
    public Vector3 distance;
    public float threshold;

    public float meal;
    public float score;
    

    GameObject[] allTargets;
    int index;

    public TMP_Text scoreText;
    public TMP_Text mealText;


    public void Awake()
    {
        
        atHome = false;
        meal = 0;
        score = 0;
        
    }

    public void Update()
    {
        distance = currentTarget.transform.position - transform.position;
       
        if (meal == 0) {
            currentTarget.transform.position = home.transform.position;
        
        }

        SetScoreText();
        SetMealText();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Delivery"))
        {
            

            if (((distance.magnitude < threshold)))
            {
                currentTarget.transform.position = home.transform.position;

                meal--;
                score++;
            }
        }

        if (collision.gameObject.CompareTag("Home"))
            
        {
            atHome = true;
            

            if ((distance.magnitude < threshold))
            {

                allTargets = GameObject.FindGameObjectsWithTag("Delivery");
                index = Random.Range(0, allTargets.Length);
                currentTarget.transform.position = allTargets[index].transform.position;
                meal++;

            } 
        }

        }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Home"))

        {
            atHome = false;
        }


    }




    private void SetScoreText()
    {

    
    scoreText.text = "Score: " + score;

    }

    private void SetMealText()
    {


        mealText.text = "Meals: " + meal;

    }
}
