using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniCycleLookForward : MonoBehaviour
{
    
    public GameObject wheel ;
    public Quaternion wheelQuat;

    private void Awake()
    {
      
        
    }

    private void LateUpdate()
    {
        wheelQuat = wheel.transform.rotation;
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, wheelQuat.eulerAngles.y, transform.eulerAngles.z);

    }

}
