using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demon : MonoBehaviour
{
    Text debugText;
    public bool showDebugCanvas;
    public float sensingRange = 5.0f;
    public float attackingRange = 2.5f;
    StateMachine stateMachine;  
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = gameObject.GetComponent<StateMachine>();

        debugText = GameObject.FindGameObjectWithTag("DemonDebugText").GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {

        if (showDebugCanvas)
        {
            debugText.text = stateMachine.strStateDebug;
        }
    }
}
