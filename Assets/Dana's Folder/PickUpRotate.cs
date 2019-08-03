using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRotate : MonoBehaviour
{
    GameObject item;
    public Transform guide;
    
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("mother fakin left mouse button bitch");
            OnMouseDown();
        }
       else if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }
    }

    private void OnMouseDown()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
        Debug.Log("mouse down");
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Pickupable")
            {
                Debug.Log("hit pickup");
                item = hitColliders[i].gameObject;
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = guide.position;
                item.transform.rotation = guide.rotation;
                item.transform.parent = guide.transform;
            }
        }
        
    }

    private void OnMouseUp()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.position;
    }
}
