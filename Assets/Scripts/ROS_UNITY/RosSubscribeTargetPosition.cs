using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;
public class RosSubscribeTargetPosition : MonoBehaviour
{
    public string topic_name = "/lmm_planer_node/event/targetPositionSet"; 
    private Vector3 targetPositionUnity;

    public PlayerControllerCoordinate playerControllerCoordinate;

    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<PointMsg>(topic_name, OnCallSubscribeEventTargetPositionSet);
    }

    void OnCallSubscribeEventTargetPositionSet(PointMsg pointMsg)
    {
        // Create a new Marker instance
        Vector3 targetPositionRos = new Vector3((float)pointMsg.x, (float)pointMsg.y, (float)pointMsg.z);
        targetPositionUnity = targetPositionRos.VecRos2Unity();
        playerControllerCoordinate.SetTargetPosition(targetPositionUnity.x,targetPositionUnity.y,targetPositionUnity.z);


        Debug.Log("[INFO][RosSubscribeTargetPosition]position:"+targetPositionUnity);


    }
}
