using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header ("Attributes")]
    public float travelSpeed = 10f;

    [HideInInspector]
    public bool isGrabbed; // is grabbed will always be activated inside the player component
    [HideInInspector]
    public GameObject target; // use type 'game object' to call the actual 3d object in the scene, no constant updating of transform values will be needed
    [HideInInspector]
    public Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(isGrabbed)
        {
            // moves the item to the target position
            Vector3 currentPos = transform.position;
            Vector3 targetPos = target.transform.position;

            transform.position = Vector3.Lerp(currentPos, targetPos, Time.fixedDeltaTime * travelSpeed);
//
            //Vector3 force = new Vector3(targetPos.x, targetPos.y, targetPos.z + 1.5f) - currentPos;
            //Debug.Log("Force Value: " + force);
            //rigidBody.AddForce(force, ForceMode.VelocityChange);
        }
    }
}
