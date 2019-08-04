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

    public void OnSceneGUI()
    {

        //  if (demon.lastKnownPosition != null)
        //{
        //demon.transform.position = Handles.PositionHandle(demon.transform.position, Quaternion.identity);

        //}
        Handles.color = Color.yellow;
        demon.sensingRange = Handles.RadiusHandle(Quaternion.identity, demon.transform.position, demon.sensingRange);
        Handles.color = Color.red;
        demon.attackingRange = Handles.RadiusHandle(Quaternion.identity, demon.transform.position, demon.attackingRange);
        Handles.color = Color.blue;
        demon.targetPositionRadius = Handles.RadiusHandle(Quaternion.identity, demon.targetDestination, demon.targetPositionRadius);

    }
}