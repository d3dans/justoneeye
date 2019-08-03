using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    private Vector3? lastKnownPosition = null;
    public float senseingRange = 5.0f;
    public float attackingRange = 2.5f;
    //variables for finding player
    GameObject player;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool test = PlayerInSensingRange();
        /*if(EyeIsOpenOpen())
        {
            //isplayerinattackingrange...
        }
        else
        {
            //isplayerInSensing Range
            
            
            
            //isLastKnownExists
        }*/
    }
    private bool EyeIsOpenOpen()
    {
        return false;
        //get player left eye open
    }

    private bool PlayerInSensingRange()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, senseingRange);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.tag == "Player")
            {        
                return true;
            }
        }
        return false;
    }

    private Vector3 getPlayerPosition()
    {
        Vector3 p = Vector3.zero;
        return p;


    }

}



