using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtHome : MonoBehaviour
{
    public NewTarget newTarget;
    public void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Home"))
        { newTarget.atHome = true;
            
        }
       
    }
    public void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.CompareTag("Home"))
        {
            newTarget.atHome = false;

        }
       

    }
}
