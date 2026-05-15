using UnityEngine;

public class Item : MonoBehaviour
{
    [HideInInspector]
    public bool isGrabbed;
    [HideInInspector]
    public GameObject target; // use type game object to call the actual 3d object in the scene, no constant updating of transform values will be needed

    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(isGrabbed)
        {
            // moves the item to the target position
            rigidBody.AddForce(target.transform.position);
        }
    }
}
