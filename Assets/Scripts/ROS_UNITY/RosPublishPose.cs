using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;
using RosMessageTypes.Std;
using RosMessageTypes.Sensor;
using System.Threading;
using RosMessageTypes.Geometry;

public class RosPublishPose : MonoBehaviour
{
    public GameObject targetObject;
    
    public string topicName = "/state_estimator/pose_in_odom";
    public float publishFrequency = 0.1f;
    private float count;
    private ROSConnection rosConnection;
    // Start is called before the first frame update
    void Start()
    {
        rosConnection = ROSConnection.GetOrCreateInstance();
        rosConnection.RegisterPublisher<PoseWithCovarianceStampedMsg>(topicName);
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > publishFrequency)
        {
            Vector3 position_unity = targetObject.transform.position;
            Vector3 position_ros = position_unity.VecUnity2Ros();

            Quaternion rotation_qua_ros = targetObject.transform.rotation.QuaternionUnity2Ros();

            

            double[] covariance = new double[36];

            PointMsg pointMsg = new PointMsg(position_ros.x,position_ros.y,position_ros.z) ;//note x,z,y coordinate in unity To x,y,z coordinate
            QuaternionMsg quaternionMsg = new QuaternionMsg(x:rotation_qua_ros.x,y:rotation_qua_ros.y,z:rotation_qua_ros.z,w:rotation_qua_ros.w);

            PoseMsg poseMsg = new PoseMsg(pointMsg,quaternionMsg);
            


            PoseWithCovarianceMsg poseWithCovarianceMsg = new PoseWithCovarianceMsg(poseMsg,covariance);

            HeaderMsg headerMsg = new HeaderMsg();

            PoseWithCovarianceStampedMsg poseWithCovarianceStampedMsg = new PoseWithCovarianceStampedMsg(headerMsg,poseWithCovarianceMsg);





            //Publish
            rosConnection.Publish(topicName, poseWithCovarianceStampedMsg);

            count = 0f; // Reset the timer
        }  
    }
}
