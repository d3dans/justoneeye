using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBinky : MonoBehaviour
{
    public GameObject lefteye;
    public GameObject righteye;
    public GameObject openeyes;
    bool lefteyeOpen;
    bool righteyeOpen;

    void Start()
    {
        lefteyeOpen = lefteye.activeSelf;
        righteyeOpen = righteye.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("LeftEye"))
        {
            //Debug.Log("fackin lefteye");
            lefteye.SetActive(!lefteyeOpen);
            lefteyeOpen = !lefteyeOpen;
        }
        else if (Input.GetButtonDown("RightEye"))
        {
            //Debug.Log("fackin righteye");
            righteye.SetActive(!righteyeOpen);
            righteyeOpen = !righteyeOpen;
        }

        
        if(!lefteyeOpen && !righteyeOpen)//both eyes are "open"
        {
            openeyes.SetActive(true);
        }
        else
        {
            openeyes.SetActive(false);
        }

    }
}
