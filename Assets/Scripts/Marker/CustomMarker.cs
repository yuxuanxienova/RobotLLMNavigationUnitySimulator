
using UnityEngine;

public class CustomMarker:MonoBehaviour
{
    public MarkerType markerType;
    public GameObject markerObj;

    public string nameSpace;
    public int id;

    public Vector3 position;
    public Vector3 scale;
    public Quaternion rotation;

    public Color32 color;

    public void UpdateObjPose()
    {
        if(markerObj)
        {
            markerObj.transform.position = position;
            markerObj.transform.rotation = rotation;
            markerObj.transform.localScale = scale;
            markerObj.GetComponent<Renderer>().material.color = color;
        }

    }

}

public enum MarkerType
{
    Cube=1,
    Sphere=2,
    Cylinder=3,
    LineList=5

}
