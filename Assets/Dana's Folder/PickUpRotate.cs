using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRotate : MonoBehaviour
{
    //object has to be tagged with Pickupable to work & gravity = true
    //sometimes makes player v tall
    GameObject item;
    public Transform guide;
    public bool isRotatingObject;
    float rotationSpeed = 50.0f;
    
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
       else if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }

        if (item != null)
        {
            if (Input.GetButton("RotateObject"))
            {
                isRotatingObject = true;
                item.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);
            }
            else if (Input.GetButtonUp("RotateObject"))
            {
                isRotatingObject = false;
            }
        }
    }

    private void OnMouseDown()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);
        
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Pickupable")
            {
                item = hitColliders[i].gameObject;
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = guide.position;
               // item.transform.rotation = guide.rotation;
                item.transform.parent = guide.transform;
            }
        }
        
    }

    private void OnMouseUp()
    {
        if (item != null)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
            item.transform.position = guide.position;
        }
    }
}
