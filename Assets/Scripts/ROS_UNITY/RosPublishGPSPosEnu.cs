using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;
using RosMessageTypes.Std;
using RosMessageTypes.Sensor;
using System.Threading;
using RosMessageTypes.Geometry;

public class RosPublishGPSPosEnu : MonoBehaviour
{
    public GameObject targetObject;
    
    public string topicName = "/rtk_gps_driver/position_receiver_0/ros/pos_enu";
    public float publishFrequency = 0.1f;
    private float count;
    private ROSConnection rosConnection;
    // Start is called before the first frame update
    void Start()
    {
        rosConnection = ROSConnection.GetOrCreateInstance();
        rosConnection.RegisterPublisher<PointStampedMsg>(topicName);
        
    }

    // Update is called once per frame
    void Update()
    {
        // count += Time.deltaTime;
        // if (count > publishFrequency)
        // {
        //     Vector3 position = targetObject.transform.position;//get position in world coordinate
        //     //Construct messages
        //     PointMsg pointMsg = new PointMsg(position.x,position.z,position.y) ;//note x,z,y coordinate in unity To x,y,z coordinate
        //     HeaderMsg headerMsg = new HeaderMsg();

        //     PointStampedMsg pointStampedMsg = new PointStampedMsg(headerMsg,pointMsg);


        //     //Publish
        //     rosConnection.Publish(topicName, pointStampedMsg);

        //     count = 0f; // Reset the timer
        // }
        
    }
}
