using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBinky : MonoBehaviour
{
    public GameObject lefteye;
    public GameObject righteye;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("fackin fired1");
            Camera le = lefteye.GetComponent<Camera>();
            le.enabled = false;
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("fackin fired2");
            Camera le = righteye.GetComponent<Camera>();
            le.enabled = false;
        }

    }
}
