using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;
using RosMessageTypes.Std;
using RosMessageTypes.Sensor;
using System.Threading;

public class RosPublishCameraInfo : MonoBehaviour
{
    public Camera targetCamera;
    public string topicName = "/unity/camera_info";
    public float publishFrequency = 0.1f;

    public RosImagePublisher rosImagePublisher;

    private ROSConnection ros;
    private float count;

    // Start is called before the first frame update
    void Start()
    {
        //start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<CameraInfoMsg>(topicName);
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > publishFrequency)
        {
            CameraInfoMsg cameraInfoMsg = new CameraInfoMsg();
            // Header
            cameraInfoMsg.header = new HeaderMsg();

            // Height and Width
            cameraInfoMsg.height = (uint)targetCamera.pixelHeight;
            cameraInfoMsg.width = (uint)targetCamera.pixelWidth;

            // Distortion Model
            cameraInfoMsg.distortion_model = "plumb_bob"; // Example distortion model, adjust as needed

            // Distortion Coefficients (D)
            cameraInfoMsg.D = new double[5]; // Assuming 5 distortion coefficients
            // Fill in your distortion coefficients here if available

            // Camera Matrix (K)
            cameraInfoMsg.K = new double[9];
            // Fill in your camera matrix here if available
            Matrix4x4 intrinsicMatrix = CalculateCameraIntrinsicMatrix();
            cameraInfoMsg.K[0] = intrinsicMatrix[0,0];
            cameraInfoMsg.K[2] = intrinsicMatrix[0,2];
            cameraInfoMsg.K[4] = intrinsicMatrix[1,1];
            cameraInfoMsg.K[5] = intrinsicMatrix[1,2];
            cameraInfoMsg.K[8] = 1f;

            // Rotation Matrix (R)
            cameraInfoMsg.R = new double[9];
            // Fill in your rotation matrix here if available

            // Projection Matrix (P)
            cameraInfoMsg.P = new double[12];
            // Fill in your projection matrix here if available

            // Binning (binning_x, binning_y)
            cameraInfoMsg.binning_x = 0; // Example binning values, adjust as needed
            cameraInfoMsg.binning_y = 0;

            // Region of Interest (ROI)
            cameraInfoMsg.roi = new RegionOfInterestMsg(); // Leave ROI empty for now

            ros.Publish(topicName, cameraInfoMsg);

            count = 0f; // Reset the timer
        }
    }


    public Matrix4x4 CalculateCameraIntrinsicMatrix()
    {
        int imageHeight = rosImagePublisher.imageHeight;//605
        int imageWidth = rosImagePublisher.imageWidth;//1593

        float focalLength = targetCamera.focalLength; // Focal length in mm
        float sensorWidth = targetCamera.sensorSize[0]; // Sensor width in mm, or sensor size along x axis

        // Calculate the aspect ratio
        float aspectRatio = (float)imageWidth / (float)imageHeight;

        // Calculate the focal lengths in pixels (assuming square pixels)
        float focalLengthX = focalLength * imageWidth / sensorWidth;
        float focalLengthY = focalLengthX; // Assuming square pixels

        // Calculate the principal point
        float principalPointX = imageWidth / 2f;
        float principalPointY = imageHeight / 2f;

        // Construct the camera intrinsic matrix
        Matrix4x4 intrinsicMatrix = new Matrix4x4();
        intrinsicMatrix[0, 0] = focalLengthX;
        intrinsicMatrix[1, 1] = focalLengthY;
        intrinsicMatrix[0, 2] = principalPointX;
        intrinsicMatrix[1, 2] = principalPointY;
        intrinsicMatrix[2, 2] = 1f;

        // Debug.Log("Camera Intrinsic Matrix:");
        // Debug.Log(intrinsicMatrix);
        return intrinsicMatrix;
    }

}
