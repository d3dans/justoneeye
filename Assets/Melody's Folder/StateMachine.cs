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
        StartCoroutine(RunStateMachine());
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
        bool headingTowards = true;
       
        //Debug.Log("Entering While loop WalkTowards...");
       
        while (headingTowards)
        {
            //demon.SetDestination(demon.lastKnownPosition);
           Debug.Log("WalkingTowards");
            //until reached
            if (demon.isTargetPositionNear())
            {
             //   Debug.Log("Target Position is near");
                headingTowards = false;
                if (demon.playerIsInAttackRange)
                {

               //     Debug.Log("player in attack range");
                    state = Attack();
                }
                else
                {
                    state = LookFor();
                }
            }
            

            yield return null;
            // && !demon.isPlayerSensed() && !demonEyeOpened
            //or sense player
        }
        Debug.Log("You fucked up");
    }

    private IEnumerable LookFor()
    {
        int t = 10;
        while (demon.demonEyeIsOpen || demon.playerIsSensed)
        {
            Debug.Log("Looking for");
            
            yield return null;
        }
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
        while (true)
        {
            yield return new WaitForSeconds(demon.attackDuration);
            Debug.Log("attack");
            if(!demon.playerIsInAttackRange)
            {
                state = WalkTowardsLastKnownPosition();
            }
        }


        
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
