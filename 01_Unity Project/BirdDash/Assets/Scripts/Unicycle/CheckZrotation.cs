using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckZrotation : MonoBehaviour
{
    public float rotationMax;
    public float floorMax;
    public float rotationMin;
    public float floorMin;


    private void Update()
    {
        if ((this.transform.rotation.eulerAngles.z > rotationMax && this.transform.rotation.eulerAngles.z < floorMax)) 
        {
            //Debug.Log("You have fallen left");

        }

        if ((this.transform.rotation.eulerAngles.z > floorMin && this.transform.rotation.eulerAngles.z < rotationMin))
        {
           // Debug.Log("You have fallen right");

        }

        //Debug.Log(this.transform.rotation.eulerAngles.z);
    }
}
