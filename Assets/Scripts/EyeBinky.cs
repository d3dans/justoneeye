using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBinky : MonoBehaviour
{
    //these are named wrong i am sorry

    public GameObject lefteye;
    public GameObject righteye;
    public GameObject openeyes;
    public GameObject closedeyes;
    public bool righteyeOpen;
    public bool lefteyeOpen;

    void Start()
    {
        righteyeOpen = !lefteye.activeSelf;
        lefteyeOpen = !righteye.activeSelf;
    }
    
    void Update()
    {
        if(Input.GetButtonDown("RightEye"))
        {
            righteyeOpen = !righteyeOpen;
            lefteye.SetActive(!righteyeOpen);
        }
        else if (Input.GetButtonDown("LeftEye"))
        {
            lefteyeOpen = !lefteyeOpen;
            righteye.SetActive(!lefteyeOpen);
        }
        
        if(righteyeOpen && lefteyeOpen)//both eyes are "open" but no camera wb rendering
        {
            openeyes.SetActive(true);
        }
        else
        {
            if (!(righteyeOpen || lefteyeOpen))//both eyes are shut
            {
                closedeyes.SetActive(true);
            }
            else
            {
                closedeyes.SetActive(false);
            }
            openeyes.SetActive(false);
        }
    }
}
