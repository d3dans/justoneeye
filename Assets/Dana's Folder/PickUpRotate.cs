using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRotate : MonoBehaviour
{
    public Transform guide;
    public GameObject hand;
    public bool isRotatingObject = false;
    public bool canPickUp = false; 
    
    RaycastHit hit;    
    GameObject item;
    float liftStrength = 5f;
    float rotationSpeed = 50.0f;
    bool canPickup = false;

    void Start()
    {
        hand.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (canPickUp && item != null)
        {
            Vector3 liftVector = (guide.position - item.transform.position) / Time.fixedDeltaTime;

            if (liftVector.sqrMagnitude > liftStrength * liftStrength)
            {
                liftVector = liftVector.normalized * liftStrength;
            }
            item.GetComponent<Rigidbody>().velocity = liftVector;
        }
    }

    void Update()
    {
        if (item == null)
        {            
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2))
            {
                if (hit.collider.tag == "Pickupable")
                {
                    hand.SetActive(true);
                    canPickUp = true;
                }
            }
            else
            {
                hand.SetActive(false);
                canPickUp = false;
            }
        }
        else
        {
            hand.SetActive(false);
        }

        if (Input.GetMouseButton(0))
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
        //Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
        
       //for (int i = 0; i < hitColliders.Length; i++)
        //{
            //if (hitColliders[i].tag == "Pickupable")
            if(canPickUp)
            {
                item = hit.collider.gameObject;//hitColliders[i].gameObject;
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().freezeRotation = true;
            //item.transform.position = guide.position;

            // item.transform.rotation = guide.rotation;
            //item.transform.parent = guide.transform;
            }
       // }
        
    }

    private void OnMouseUp()
    {
        if (item != null)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            //item.transform.parent = null;
            // item.transform.position = guide.position;
            item.GetComponent<Rigidbody>().freezeRotation = false;
            item = null;
        }
    }
}
