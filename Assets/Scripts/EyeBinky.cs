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
    
    void Update()
    {
        if(Input.GetButtonDown("LeftEye"))
        {
            lefteye.SetActive(!lefteyeOpen);
            lefteyeOpen = !lefteyeOpen;
        }
        else if (Input.GetButtonDown("RightEye"))
        {
            righteye.SetActive(!righteyeOpen);
            righteyeOpen = !righteyeOpen;
        }
        
        if(!lefteyeOpen && !righteyeOpen)//both eyes are "open" but no camera wb rendering
        {
            openeyes.SetActive(true);
        }
        else
        {
            openeyes.SetActive(false);
        }
    }
}
