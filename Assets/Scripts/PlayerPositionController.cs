using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionController : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed;

    public float groundDrag;
    public float playerHeight;
    public LayerMask layerGround;

    bool onGround=false;

    private Rigidbody playerRigidBody;
    float horizontalInput=0f;
    float verticalInput=0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody=Player.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGroundCheck();
        UpdateGroundDrag();
        UpdateKeyboardInput();
        MovePlayer();
        
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

    private void UpdateKeyboardInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

    }

    private void MovePlayer()
    {
        Vector3 moveDirection = Player.transform.forward * verticalInput + Player.transform.right * horizontalInput;
        if(onGround)
        {
            playerRigidBody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }
}
