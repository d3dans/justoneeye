using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{    
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f);
        
        for(int i = 0; i< hitColliders.Length; i++)
        {
            if(hitColliders[i].tag == "Player")
            {
                hitColliders[i].GetComponent<Respawn>().respawnpoint = transform;
            }
        }
    }
}
