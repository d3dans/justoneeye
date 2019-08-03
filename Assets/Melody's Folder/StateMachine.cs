using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IEnumerable state;
    private GameObject player;
    public string strStateDebug;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        state = DebugLogState("Hello");
        //Debug.Log("Starting state machine");
        //StartCoroutine(RunStateMachine());
    }

    public IEnumerator RunStateMachine()
    {
        while(state != null)
        {
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
        while (!positionReached && !playerSensed && !demonEyeOpened)
        {
            //until reached

            //or sense player
            yield return null;


        }
    }
    private IEnumerable DebugLogState(string message)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            //Debug.Log(message);


        }
    }
    #endregion
    #region Scenario Checks
    private bool isPositionReached(Vector3 p)
    {
        if (Vector3.Distance(p, transform.position) < 0.01)
        {
            return true;
        }
        return false;
    }
    #endregion



    // Update is called once per frame
    void Update()
    {
        strStateDebug = state.ToString();
    }
}
