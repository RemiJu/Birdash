using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialTarget : MonoBehaviour
{
    public GameObject currentTarget;
    public Transform tutoTarget;
    public Vector3 distance;
    public float threshold;

    public TutoSuccessMenu tutoSuccessMenu;

    
    public SoundManager soundManager;

    public void Awake()
    {

       
       
       

    }

    public void Update()
    {
        distance = currentTarget.transform.position - transform.position;

     

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("TutoTarget"))
        {


            if (((distance.magnitude < threshold)))
            {



                soundManager.Delivered();
                tutoSuccessMenu.SuccessGame();

            }
        }




    }


    
}
