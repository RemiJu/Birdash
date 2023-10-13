using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckZrotation : MonoBehaviour
{
    public float rotationMax;
    public float floorMax;
    public float rotationMin;
    public float floorMin;
    public PlayerController playerController;
    public GameObject explosion;
    public bool coroutinePLaying = false;

    public DeadMenu deadMenu;
    public SoundManager soundManager;

   


    private void Update()
    {




        if ((this.transform.rotation.eulerAngles.z > rotationMax && this.transform.rotation.eulerAngles.z < floorMax))
        {
            if (!coroutinePLaying)
            {
                StartCoroutine(DeadSequance());
                coroutinePLaying = true;
            }

        }

        if ((this.transform.rotation.eulerAngles.z > floorMin && this.transform.rotation.eulerAngles.z < rotationMin))
        {
            if (!coroutinePLaying)
            {
                StartCoroutine(DeadSequance());
                coroutinePLaying = true;
            }

        }

        //Debug.Log(this.transform.rotation.eulerAngles.z);


    }

    public IEnumerator DeadSequance()
    {
        
        soundManager.FallingSound();
        GameObject.Instantiate(explosion, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        coroutinePLaying = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        deadMenu.endGame();
    }
}
