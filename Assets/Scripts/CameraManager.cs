using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject camera_player;
    public GameObject playerCameraPosIndicator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateCameraPlayer();
        
    }

    private void updateCameraPlayer()
    {
        camera_player.transform.position = playerCameraPosIndicator.transform.position;
        camera_player.transform.rotation = playerCameraPosIndicator.transform.rotation;
    }
}
