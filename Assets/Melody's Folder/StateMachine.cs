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
        state = WalkTowardsLastKnownPosition();
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
        bool positionReached = false;
        bool playerSensed = false;
        bool demonEyeOpened = false;
        Debug.Log("Entering While loop");
        demon.SetDestination(demon.lastKnownPosition);
        while (!positionReached && !playerSensed && !demonEyeOpened)
        {
          //  Debug.Log("In WalkTowardsLastKnownPosition Loop");
            //until reached
            if(demon.isTargetPositionNear())
            {
                //attack
                //Take Dammage() th3en wait Tahe Damage Then wait...
                state = DebugLogState("target position reached");
            }
            

            yield return null;
            // && !demon.isPlayerSensed() && !demonEyeOpened
            //or sense player
        }
        Debug.Log("You fucked up");
    }
    private IEnumerable DebugLogState(string message)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            //Debug.Log(message);


        }
    }

    private IEnumerable Attack()
    {
        yield return null;
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
