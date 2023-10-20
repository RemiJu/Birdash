using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CrashSequence : MonoBehaviour
{
    GameObject[] allTargets;
    int index;

    public GameObject EnemyBird;
    
    public void Awake()
    {
        if (this.gameObject.CompareTag("EnemyBird"))
        {
            return;
        }
        if (this.gameObject.CompareTag("Crash"))
            {
                StartCoroutine(CrashSequenceStart());
            }

    }


    public IEnumerator CrashSequenceStart()
    {
        
        yield return new WaitForSeconds(10);

        allTargets = GameObject.FindGameObjectsWithTag("Delivery");
        index = UnityEngine.Random.Range(0, allTargets.Length);
       

        Instantiate(EnemyBird, allTargets[index].transform.position, allTargets[index].transform.rotation);
        Destroy(this.gameObject);
    }

    public void DestroyThisEnemyBird() {
        Destroy(this.gameObject);
    }
}
