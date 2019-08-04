using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class Demon : MonoBehaviour
{
    public int attack = 20;
    public int attackDuration = 20;

    public float sensingRange = 5.0f;
    public float attackingRange = 2.5f;
    public float targetPositionRadius = 5.0f;
    
    StateMachine stateMachine;  
    public Vector3 lastKnownPosition { get; private set; }
    
    public bool demonEyeIsOpen { get; private set; }
   
    public bool playerIsSensed { get; private set; }
   
    public bool playerIsInAttackRange { get; private set; }
    public Vector3 targetDestination;
    //Demon Movement 

    NavMeshAgent _navMeshAgent;
    //refrence to player
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //movement
        player = GameObject.FindGameObjectWithTag("Player");
        lastKnownPosition = transform.position;
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent is not attached to " + gameObject.name);
        }
        

        stateMachine = gameObject.GetComponent<StateMachine>();


       // debugText = GameObject.FindGameObjectWithTag("DemonDebugText").GetComponent<Text>();   
    }
    //this should not be public change when theres time
    

    // Update is called once per frame
    void Update()
    {
        //get eye blinky script
        demonEyeIsOpen = GameObject.FindGameObjectWithTag("Player").GetComponent<EyeBinky>().lefteyeOpen;
        //idfk this just seems more oganized
       // Debug.Log("Demon Eye Is Open: " + demonEyeIsOpen);
        playerIsSensed = OverlapSphereCheck(sensingRange);

        playerIsInAttackRange = OverlapSphereCheck(attackingRange);
       _navMeshAgent.destination = targetDestination;
        
        //Debug.Log("Destination: " + _navMeshAgent.destination);
        //Debug.Log("Distance Remaining: " + _navMeshAgent.remainingDistance);

        //Debug.Log("State: " + stateMachine.strStateDebug);
        if (demonEyeIsOpen || playerIsSensed)
        {
            UpdateLastKnownPosition();
        }
        
    }

    private void FixedUpdate()
    {

    }
    /*
    public bool isPlayerSensed()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, sensingRange);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }
    */
    public bool isTargetPositionNear(float radius = 5.0f)
    {
        Debug.Log("inside isTarget...  remaindist: " + _navMeshAgent.remainingDistance);
        return (_navMeshAgent.remainingDistance < radius);  
        
    }

   /* public bool isPlayerInAttackRange()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, attackingRange);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }
    */
    public void UpdateLastKnownPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        targetDestination = player.transform.position;

    }

    private bool OverlapSphereCheck(float Radius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, attackingRange);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetDestination, targetPositionRadius);
    }

}
