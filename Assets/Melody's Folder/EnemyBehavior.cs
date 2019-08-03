using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    private Vector3? lastKnownPosition = null;

    //variables for finding player
    GameObject player;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(EyeIsOpenOpen())
        {
            //isplayerinattackingrange...
        }
        else
        {
            //isplayerInSensing Range
            
            
            
            //isLastKnownExists
        }
    }
    private bool EyeIsOpenOpen()
    {
        return false;
        //get player left eye open
    }

    private bool PlayerInSensingRange()
    {

        return false;
    }


}



