using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnpoint; //set on start to a starting respawn position
    
    public void RespawnPlayer()
    {
        //yeet player
        transform.position = respawnpoint.position;        
    }
}
