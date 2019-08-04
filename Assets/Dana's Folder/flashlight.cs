using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public bool flashlightOn = false;
    public GameObject flashlightObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Flashlight"))
        {
            Debug.Log("flashlight");
            if(flashlightOn)
            {
                flashlightObject.SetActive(false);
                flashlightOn = false;
            }
            else
            {
                flashlightObject.SetActive(true);
                flashlightOn = true;
            }
        }
    }
}
