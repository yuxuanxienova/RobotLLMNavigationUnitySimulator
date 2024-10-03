using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerViewControlType
{
    MouseControl,
    KeyBoardControl
}
public class PlayerOrientationController : MonoBehaviour
{
    public  PlayerViewControlType playerViewControlType;
    public float sensX;
    public float sensY;

    public GameObject Player;

    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerViewControlType==PlayerViewControlType.MouseControl)
        {
            UpdateViewMouseControl();
        }
        else if(playerViewControlType==PlayerViewControlType.KeyBoardControl)
        {
            UpdateViewKeyboardControl();

        }


        
    }

    void UpdateViewMouseControl()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        //get mouse input 
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;


        yRotation += mouseX;

        xRotation -= mouseY;

        //Clamp the rotation
        xRotation = Mathf.Clamp(xRotation, -90f,90f);

        //Rotate can and Orientaiton
        Player.transform.rotation = Quaternion.Euler(xRotation,yRotation,0);

    }

    void UpdateViewKeyboardControl()
    {
        Cursor.lockState = CursorLockMode.None;
        
        if(Input.GetKey(KeyCode.E))
        {
            yRotation += Time.deltaTime * sensY;
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            yRotation -= Time.deltaTime * sensY;

        }
        Player.transform.rotation = Quaternion.Euler(xRotation,yRotation,0);


    }


}
