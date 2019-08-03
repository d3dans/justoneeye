using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IEnumerable state;
    
    // Start is called before the first frame update
    void Start()
    {
        state = DebugLogState("Hello");
        Debug.Log("Starting state machine");
        StartCoroutine(RunStateMachine());
    }

    public IEnumerator RunStateMachine()
    {
        while(state != null)
        {
            Debug.Log("State Machine Running");
            foreach (var c in state)
            {
                Debug.Log("in foreach loop");
                yield return c;
            }
        
        }
    }

    private IEnumerable DebugLogState(string message)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(message);

        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
