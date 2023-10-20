using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class NewTargetAi : MonoBehaviour
{
    public GameObject currentTarget;
    public Transform home;
    public bool atHome;
    private Vector3 distance;
    public float threshold;

    public float meal;
   
    

    GameObject[] allTargets;
    int index;

 
    

    public void Awake()
    {
        home = GameObject.FindGameObjectWithTag("HomeAI").transform;
        
        atHome = false;
        meal = 0;
        
        
    }

    public void Update()
    {
        distance = currentTarget.transform.position - transform.position;
       
        if (meal == 0) {
            currentTarget.transform.position = home.transform.position;
        
        }

        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Delivery"))
        {
            

            if (((distance.magnitude < threshold)))
            {
                currentTarget.transform.position = home.transform.position;

                meal--;
             

            }
        }

        if (collision.gameObject.CompareTag("HomeAI"))
            
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
        if (collision.gameObject.CompareTag("HomeAI"))

        {
            atHome = false;
        }


    }




    
}
