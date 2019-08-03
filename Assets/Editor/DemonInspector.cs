using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Demon))]
public class DemonInspector : Editor
{
    Demon demon;


    void OnEnable()
    {
        demon = (Demon)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    private void OnSceneGUI()
    {

        //  if (demon.lastKnownPosition != null)
        //{
        //Handles.PositionHandle(stateMachine.lastKnownPosition, Quaternion.identity);

        //}
        Handles.color = Color.yellow;
        demon.sensingRange = Handles.RadiusHandle(Quaternion.identity, demon.transform.position, demon.sensingRange);
        Handles.color = Color.red;
        demon.attackingRange = Handles.RadiusHandle(Quaternion.identity, demon.transform.position, demon.attackingRange);
    }
}