using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnpoint; //set on start to a starting respawn position
    public float health = 100f;

    //TEST CODE
    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Damage")
            {
                TakeDamage(100f);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if(damage > health)
        {
            health = 0;
        }
        else
        {
            health=- damage;
        }

        if(health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        //do something pretty
        RespawnPlayer();
    }
    
    public void RespawnPlayer()
    {
        transform.position = respawnpoint.position;
        health = 100;
    }
}
