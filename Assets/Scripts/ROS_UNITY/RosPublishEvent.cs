using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;
using RosMessageTypes.Std;
using RosMessageTypes.Sensor;
using System.Threading;
using RosMessageTypes.Geometry;

public class RosPublishEvent : MonoBehaviour
{
    private ROSConnection rosConnection;
    private void Start()
    {
        rosConnection = ROSConnection.GetOrCreateInstance();
        rosConnection.RegisterPublisher<StringMsg>("/lmm_planer_node/event/unity/targetReach");
    }
    public void PublishEventTargetReach()
    {
        StringMsg stringMsg = new StringMsg("call");
        rosConnection.Publish("/lmm_planer_node/event/unity/targetReach",stringMsg);

    }
}
