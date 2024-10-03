using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;
using RosMessageTypes.Std;
using RosMessageTypes.Sensor;
using System.Threading;

public class RosImagePublisher : MonoBehaviour
{
    public Camera targetCamera;
    public string topicName = "/unity/image_fp";
    public float publishFrequency = 0.1f;

    private ROSConnection ros;
    private RenderTexture renderTexture;
    private Texture2D texture;
    private float count;

    [HideInInspector]
    public int imageWidth ;
    [HideInInspector]
    public int imageHeight ;

    // Start is called before the first frame update
    void Start()
    {
        //start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<ImageMsg>(topicName);

        renderTexture = new RenderTexture(targetCamera.pixelWidth, targetCamera.pixelHeight, 24);
        targetCamera.targetTexture = renderTexture;

        texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        imageWidth = renderTexture.width;
        imageHeight = renderTexture.height;

        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > publishFrequency)
        {
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture.Apply();
            RenderTexture.active = null;

            byte[] imageData = TextureToByteArrayBGR8(texture);// You may use other encoding methods

            ImageMsg imageMsg = new ImageMsg
            {
                header = new HeaderMsg(), // You may need to fill in header details
                height = (uint)texture.height,
                width = (uint)texture.width,
                encoding = "bgr8",
                data = imageData
            };

            ros.Publish(topicName, imageMsg);

            count = 0f; // Reset the timer
        }
    }
    // Convert Texture2D to byte array in BGR8 format
    private byte[] TextureToByteArrayBGR8(Texture2D texture)
    {
        Color[] pixels = texture.GetPixels();
        byte[] byteArray = new byte[pixels.Length * 3]; // 3 channels (BGR)
        int byteIndex = 0;
        int width = texture.width;
        int height = texture.height;

        // Iterate over the rows of the texture in reverse order
        for (int y = height - 1; y >= 0; y--)
        {
            for (int x = 0; x < width; x++)
            {
                // Get pixel color
                Color pixel = pixels[y * width + x];
                // Convert color channels from range [0, 1] to range [0, 255]
                byte blue = (byte)(pixel.b * 255);
                byte green = (byte)(pixel.g * 255);
                byte red = (byte)(pixel.r * 255);
                // Populate byte array in BGR order
                byteArray[byteIndex++] = blue;
                byteArray[byteIndex++] = green;
                byteArray[byteIndex++] = red;
            }
        }
        return byteArray;
    }
}

