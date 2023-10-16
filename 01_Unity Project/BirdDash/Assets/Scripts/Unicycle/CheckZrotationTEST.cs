using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckZrotationTEST : MonoBehaviour
{
    public float rotationMax;
    public float floorMax;
    public float rotationMin;
    public float floorMin;
    public PlayerController playerController;





    private void Update()
    {




        if ((this.transform.rotation.eulerAngles.z > rotationMax && this.transform.rotation.eulerAngles.z < floorMax))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if ((this.transform.rotation.eulerAngles.z > floorMin && this.transform.rotation.eulerAngles.z < rotationMin))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        //Debug.Log(this.transform.rotation.eulerAngles.z);


    }
}
