using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Visualization;


public class RosSubscribeVisualizationMarker : MonoBehaviour
{
    public string topic_name = "/lmm_planer_node/event/visualization_marker";

    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<MarkerMsg>(topic_name, OnCallSubscribeMarker);
    }

    void OnCallSubscribeMarker(MarkerMsg markerMsg)
    {
        // Create a new Marker instance


        string nameSpace = markerMsg.ns;
        int id = markerMsg.id;
        
        MarkerType markerType = (MarkerType)markerMsg.type;

        // Assign position
        Vector3 position_ros = new Vector3((float)markerMsg.pose.position.x, (float)markerMsg.pose.position.y, (float)markerMsg.pose.position.z);
        Vector3 position_unity = position_ros.VecRos2Unity();

        // Assign rotation
        Quaternion rotation_qua_ros = new Quaternion((float)markerMsg.pose.orientation.x, (float)markerMsg.pose.orientation.y, (float)markerMsg.pose.orientation.z, (float)markerMsg.pose.orientation.w);


        // Assign scale
        Vector3 scale_ros = new Vector3((float)markerMsg.scale.x, (float)markerMsg.scale.y, (float)markerMsg.scale.z);
        Vector3 scale_unity = scale_ros.VecRos2Unity();

        //Assign color
        Color32 color = new Color32((byte)(markerMsg.color.r * 255), (byte)(markerMsg.color.g * 255), (byte)(markerMsg.color.b * 255), (byte)(markerMsg.color.a * 255));

        VisualizationMarkerManager.Instance.UpdateMarker(nameSpace, id, markerType,position_unity, rotation_qua_ros.QuaternionRos2Unity(), scale_unity, color);
        // Debug.Log("[INFO][RosSubscribeVisualizationMarker]type: "+ markerMsg.type+"; position:"+position_unity);


    }
}
