using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IEnumerable state;
    private GameObject player;
    public string strStateDebug;
    private Demon demon;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        demon = gameObject.GetComponent<Demon>();
        state = LookFor();
        //Debug.Log("Starting state machine");
        //StartCoroutine(RunStateMachine());
    }

    public IEnumerator RunStateMachine()
    {
        while(state != null)
        {
            Debug.Log("state machine running");
            //Debug.Log("State Machine Running");
            foreach (var c in state)
            {
               // Debug.Log("in foreach loop");
                yield return c;
            }
        
        }
    }
    #region States
    private IEnumerable WalkTowardsLastKnownPosition()
    {
        
       
        Debug.Log("Entering While loop WalkTowards...");
       
        while (!demon.isTargetPositionNear())
        {
            //demon.SetDestination(demon.lastKnownPosition);
           Debug.Log("WalkingTowards");
            yield return null;
            // && !demon.isPlayerSensed() && !demonEyeOpened
            //or sense player
        }
        if (demon.playerIsInAttackRange)
        {

            //     Debug.Log("player in attack range");
            state = Attack();

        }
        else
        {
            state = LookFor();
        }
        Debug.Log("You fucked up");
    }

    private IEnumerable LookFor()
    {
        int t = 10;
        while (!demon.demonEyeIsOpen/* && !demon.playerIsSensed*/)
        {
            Debug.Log("Looking for");
            
            yield return null;
        }
        Debug.Log("Out of look for while loop");
        state = WalkTowardsLastKnownPosition();
    }

    private IEnumerable DebugLogState(string message)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(message);


        }
    }

    private IEnumerable Attack()
    {
        Debug.Log("inside attack");
        while (demon.playerIsInAttackRange)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Respawn>().TakeDamage(demon.attack);
            yield return new WaitForSeconds(demon.attackDuration);
            Debug.Log("attack");
            
        }
        
        state = WalkTowardsLastKnownPosition();
    }

    private IEnumerable Wander()
    {
        
        bool wander = true;
        while (wander)//
        {
            if(demon.playerIsSensed)
            {
                state = WalkTowardsLastKnownPosition();
            }
            if(demon.demonEyeIsOpen)
            {
                WalkTowardsLastKnownPosition();
            }

            //set position solmething
            Debug.Log("in wander");
            yield return null;
        }



    }
    #endregion
    #region Scenario Checks



    #endregion



    // Update is called once per frame
    void Update()
    {
        strStateDebug = state.ToString();
    }
}
