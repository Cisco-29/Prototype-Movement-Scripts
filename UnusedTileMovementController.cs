using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovementController : MonoBehaviour {

    [SerializeField] private float distanceToMove;
    [SerializeField] private float moveSpeed;

    private bool moveToPoint = false;
    private Vector3 endPosition;

    //Initialise

    void Start()
    {
        endPosition = transform.position;
        moveToPoint = false;
    }

    void FixedUpdate() 

    /* FixedUpdate should be used when applying forces, torques, or other 
     * physics-related functions - because you know it will be executed exactly 
     * in sync with the physics engine itself. This line is used to physically 
     * move the player sprite*/

    {
        if (moveToPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }
    }
    void Update() // Input and Logic
    {
        if (Input.GetKey(KeyCode.A) && !moveToPoint) //Left
        {
            endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
            moveToPoint = true;
        }
        if (Input.GetKey(KeyCode.D) && !moveToPoint) //Right
        {
            endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
            moveToPoint = true;
        }
        if (Input.GetKey(KeyCode.W) && !moveToPoint) //Up
        {
            endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
            moveToPoint = true;
        }
        if (Input.GetKey(KeyCode.S) && !moveToPoint) //Down
        {
            endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
            moveToPoint = true;
        }

        // check for destination

 //       if (endPosition.x == transform.position && endPosition.y == transform.position)
        { }
    }
}