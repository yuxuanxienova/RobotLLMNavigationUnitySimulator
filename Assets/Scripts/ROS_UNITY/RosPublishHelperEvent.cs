using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;
using RosMessageTypes.Std;
using RosMessageTypes.Sensor;
using System.Threading;
using RosMessageTypes.Geometry;

public class RosPublishHelperEvent : MonoBehaviour
{   
    private ROSConnection rosConnection;
    private void Start()
    {
        rosConnection = ROSConnection.GetOrCreateInstance();
        rosConnection.RegisterPublisher<StringMsg>("/lmm_sf_node/helper_event/nav_graph_constructor/recordPositionIfReady");
    }
    public void PublishEventDirectCallRecordPositionIfReady()
    {
        StringMsg stringMsg = new StringMsg("call");
        rosConnection.Publish("/lmm_sf_node/helper_event/nav_graph_constructor/recordPositionIfReady",stringMsg);

    }


}
