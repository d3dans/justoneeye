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
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       

        if (PlayerInSensingRange())
        {
            DashAtPlayer();
        }
        else
        {
            if(IsDemonEyeOpen())
            {

            }
        }
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

    private void DashAtPlayer()
    {

        float step = 1 * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    private bool IsDemonEyeOpen()
    {
        return false;
    }
}



