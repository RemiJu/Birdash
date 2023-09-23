using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewTarget : MonoBehaviour
{
    public GameObject currentTarget;
    public Transform home;
    public bool atHome;
    public int meals;

    GameObject[] allTargets;
    int index;


    
    public void Start()
    {
        currentTarget = this.gameObject;
        atHome = false;
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            

            if (((currentTarget.transform.position != home.transform.position) && !atHome)) 
            {
                currentTarget.transform.position = home.transform.position;
                currentTarget.GetComponent<SpriteRenderer>().enabled = false;
               
            }

            else if (currentTarget.transform.position == home.transform.position && atHome)
            {
                
                allTargets = GameObject.FindGameObjectsWithTag("targets");
                index = Random.Range(0, allTargets.Length);
                currentTarget.transform.position = allTargets[index].transform.position;

                currentTarget.GetComponent<SpriteRenderer>().enabled = true;
            }

        }


        
    }


}
