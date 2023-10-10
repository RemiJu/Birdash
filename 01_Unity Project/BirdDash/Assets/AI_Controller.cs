using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Controller : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;

    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        GoToTarget();
    }
    public void GoToTarget() {
        agent.SetDestination(target.transform.position);
    
    }
}
