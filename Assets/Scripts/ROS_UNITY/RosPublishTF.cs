using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;
using RosMessageTypes.Std;
using RosMessageTypes.Sensor;
using RosMessageTypes.Tf2;
using RosMessageTypes.Geometry;
using System.Threading;

public class RosPublishTF : MonoBehaviour
{

    private string topicName = "/tf";
    public float publishFrequency = 0.1f;

    private ROSConnection ros;
    private float count;

    // Start is called before the first frame update
    void Start()
    {
        //start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<TFMessageMsg>(topicName);
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > publishFrequency)
        {
            // Create a new TFMessage
            // TFMessageMsg tfMessage = new TFMessageMsg();
            // tfMessage.transforms = new TransformStampedMsg[1];

            // // Create and populate the TransformStamped message
            // TransformStampedMsg transformStamped = new TransformStampedMsg();

            // // Set the header
            // transformStamped.header = new HeaderMsg();
            // transformStamped.header.stamp = ros::Time::now(); // Current time
            // transformStamped.header.frame_id = "world"; // Reference frame ID

            // // Set the child frame ID
            // transformStamped.child_frame_id = "camera_frame"; // Child frame ID

            // // Set the transform
            // transformStamped.transform = new TransformMsg();

            // // Example: Set translation (in meters)
            // transformStamped.transform.translation = new Vector3Msg();
            // transformStamped.transform.translation.x = transform.position.x;
            // transformStamped.transform.translation.y = transform.position.y;
            // transformStamped.transform.translation.z = transform.position.z;

            // // Example: Set rotation (quaternion)
            // transformStamped.transform.rotation = new QuaternionMsg();
            // transformStamped.transform.rotation.x = transform.rotation.x;
            // transformStamped.transform.rotation.y = transform.rotation.y;
            // transformStamped.transform.rotation.z = transform.rotation.z;
            // transformStamped.transform.rotation.w = transform.rotation.w;

            // // Assign the TransformStamped to the TFMessage
            // tfMessage.transforms[0] = transformStamped;

            // // Publish the TFMessage
            // ros.Publish(topicName, tfMessage);

            // count = 0f; // Reset the timer
        }
    }


}
