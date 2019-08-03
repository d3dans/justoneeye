using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StateMachine))]
public class StateMachineInspector : Editor
{
    StateMachine stateMachine;


    void OnEnable()
    {
        stateMachine = (StateMachine)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    private void OnSceneGUI()
    {

      /*  if (stateMachine.lastKnownPosition != null)
        {
            //Handles.PositionHandle(stateMachine.lastKnownPosition, Quaternion.identity);
            
        }
        stateMachine.sensingRange = Handles.RadiusHandle(Quaternion.identity, stateMachine.transform.position, stateMachine.sensingRange);
    */
    }
}