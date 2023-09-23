using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewTarget : MonoBehaviour
{
    public GameObject currentTarget;
    public Transform home;
    public bool atHome;
    public Vector3 distance;
    public float threshold;
    

    GameObject[] allTargets;
    int index;


    
    public void Start()
    {
        currentTarget = this.gameObject;
        atHome = false;
        
    }

    public void Update()
    {
        distance = currentTarget.transform.position - transform.position;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            if (((distance.magnitude < threshold) && !atHome))
            {
                currentTarget.transform.position = home.transform.position;
                currentTarget.GetComponent<SpriteRenderer>().enabled = false;

            }

            else if ((distance.magnitude < threshold) && atHome)
            {
                
                allTargets = GameObject.FindGameObjectsWithTag("targets");
                index = Random.Range(0, allTargets.Length);
                currentTarget.transform.position = allTargets[index].transform.position + new Vector3(0, 20, 0);

                currentTarget.GetComponent<SpriteRenderer>().enabled = true;
            }

        }


        
    }


}
