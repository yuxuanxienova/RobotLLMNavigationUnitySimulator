using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCoordinate : MonoBehaviour
{
    public Transform Player; // Reference to the player transform
    public Rigidbody playerRigidBody; // Reference to the player's Rigidbody
    public float moveSpeed = 5f; // Movement speed
    public bool onGround = true; // Check if player is on the ground
    public Vector3 targetPosition; // The target position to move the player to
    public Vector3 faceDirection;
    public float groundDrag;
    public float playerHeight;
    public LayerMask layerGround;

    public bool flagReachTargetPublish = false;
    public float targetThreshold = 0.8f; // Distance threshold to consider as reached target
    public RosPublishEvent rosPublishEvent;

    void Start()
    {
        faceDirection = Player.forward;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateGroundCheck();
        UpdateGroundDrag();
        MovePlayer();


    }

    public void SetTargetPosition(float _x, float _y, float _z)
    {
        targetPosition = new Vector3(_x, _y, _z);
        flagReachTargetPublish= false;

        //Set Heading here
        Vector3 moveDirection = (targetPosition - Player.position).normalized;
        moveDirection[1] = 0;
        SetTargetHeading(moveDirection);
    }

    public void SetTargetHeading(Vector3 headingDirection)
    {
        faceDirection = headingDirection;

    }
    private void UpdateGroundCheck()
    {
        onGround = Physics.Raycast(transform.position,Vector3.down,playerHeight * 0.5f + 0.2f, layerGround);
    }

    private void UpdateGroundDrag()
    {
        if(onGround)
        {
            playerRigidBody.drag = groundDrag;
        }
        else
        {
            playerRigidBody.drag = 0;
        }
    }

    private void MovePlayer()
    {
        //update the heading
        Player.rotation = Quaternion.LookRotation(faceDirection); 

        
        if (onGround)
        {
            Vector3 moveDirection = (targetPosition - Player.position).normalized;
            moveDirection[1] = 0; // Ensure y component is 0
            // Check if player has reached the target position within a threshold
            if (moveDirection.magnitude < targetThreshold && !flagReachTargetPublish)
            {
                Debug.Log("[INFO] Player has reached the target position.");
                rosPublishEvent.PublishEventTargetReach();
                flagReachTargetPublish= true;
                return;
            }

            if (moveDirection.magnitude < targetThreshold)
            {
                playerRigidBody.AddForce(moveDirection * moveSpeed * 1f, ForceMode.Force);
            }
            else
            {
                playerRigidBody.AddForce(moveDirection * moveSpeed * 10f, ForceMode.Force);
            }
        }
    }
}
