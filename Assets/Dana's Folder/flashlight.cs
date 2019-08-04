using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public bool flashlighton = false;
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
            if(flashlighton)
            {
                flashlightObject.SetActive(false);
                flashlighton = false;
            }
            else
            {
                flashlightObject.SetActive(true);
                flashlighton = true;
            }
        }
    }
}
