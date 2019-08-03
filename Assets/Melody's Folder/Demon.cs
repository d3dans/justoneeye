using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demon : MonoBehaviour
{
    Text debugText;
    public bool showDebugLogState;
    public float sensingRange = 5.0f;
    public float attackingRange = 2.5f;
    public float targetPositionRadius = 5.0f;
    StateMachine stateMachine;  
    public Vector3 lastKnownPosition { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = gameObject.GetComponent<StateMachine>();

       // debugText = GameObject.FindGameObjectWithTag("DemonDebugText").GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {

        if (showDebugLogState)
        {
            Debug.Log("State: " + stateMachine.strStateDebug);
        }
    }

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

    public bool isTargetPositionReached(Vector3 p)
    {
        if (Vector3.Distance(p, transform.position) < 0.01)
        {
            return true;
        }
        return false;
    }
}
