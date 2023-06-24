using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickUp : MonoBehaviour
{
    [SerializeField] private LayerMask pickUpMask;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform pickUpTarget;
    [Space]
    [SerializeField] private float pickUpRange;
    private Rigidbody currentObject;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        { 

            if (currentObject)
            {             
                currentObject.useGravity = true;
                currentObject = null;
                return; 
            }

            Ray CameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if(Physics.Raycast(CameraRay,out RaycastHit HitInfo, pickUpRange, pickUpMask))
            {
                currentObject = HitInfo.rigidbody;
                currentObject.useGravity = false; 
            }
        }
    }

    void FixedUpdate()
    {

        if (currentObject)
        {
            Vector3 directionsToPoint = pickUpTarget.position - currentObject.position;
            float distanceToPoint = directionsToPoint.magnitude;

            currentObject.velocity = directionsToPoint * 12f * distanceToPoint; 
        }

    }
}
