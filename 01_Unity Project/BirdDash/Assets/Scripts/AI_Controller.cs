using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Controller : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target; //reference to the moving target
    public NewTargetAi targetAi; //reference to the script
    public float meal;
    public bool sentMessage;

    public GameObject crash;
    public GameObject Condor;

    public GameObject enemy;

    //set colliderMeal to true if collider has a meal
    public bool colliderMeal;
    public bool thisHasMeal;

    


    public void Awake()
    {
        sentMessage = false;
        agent = GetComponent<NavMeshAgent>();
        targetAi = GetComponentInChildren<NewTargetAi>();
        colliderMeal = false;
    }
    private void Update()
    {
        GoToTarget();

        if (targetAi.meal > 0) {
            thisHasMeal = true;
        }
        else { thisHasMeal = false; }

        if (thisHasMeal && !colliderMeal && !sentMessage && enemy != null) 
        {
            StartCoroutine(CrashSequence());
            //Debug.Log(this.gameObject + " FIGHT with " + enemy + " !");
            sentMessage = true;
        }
        if (!thisHasMeal && colliderMeal && !sentMessage)
        {
            StartCoroutine(CrashSequence());
            //Debug.Log(this.gameObject + " FIGHT with " + enemy + " !");
            sentMessage = true;
        }
    }
    public void GoToTarget() {
        agent.SetDestination(target.transform.position);
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBird")) {

            enemy = other.gameObject;

            if (targetAi.meal > 0)
            {
                //Debug.Log(this.gameObject + " has a meal.");
                other.SendMessage("IHasMeal");
            }
            else
            {
                //Debug.Log(this.gameObject + " has no meal.");
                other.SendMessage("IHasNoMeal");
            }
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBird"))
        {
            if (colliderMeal)
            {
                colliderMeal = false;
            }
            sentMessage = false;

            enemy = null;

        }
    }

    public void IHasMeal() {
        colliderMeal = true;
    }

    public void IHasNoMeal() {
    colliderMeal = false;
    }

    public IEnumerator CrashSequence()
    {
        Instantiate(crash, this.transform.position, this.transform.rotation);
        yield return new WaitForEndOfFrame();
        
        SendMessageUpwards("DestroyThisEnemyBird");
    }
}
