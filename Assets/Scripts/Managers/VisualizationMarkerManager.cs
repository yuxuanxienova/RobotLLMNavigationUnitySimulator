using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizationMarkerManager : Singleton<VisualizationMarkerManager>
{
    public GameObject markerCube;
    public GameObject markerSphere;
    public GameObject markerCylinder;

    public Dictionary<string,Dictionary<int,CustomMarker>> namespaceIdToMarkerDict = new Dictionary<string,Dictionary<int,CustomMarker>>();

    public void UpdateMarker(string _nameSpace, int _id, MarkerType _markerType, Vector3 _position, Quaternion _rotation, Vector3 _scale, Color32 _color)
    {
    
        // Check if the namespace exists in the dictionary
        if (!namespaceIdToMarkerDict.ContainsKey(_nameSpace))
        {
            // If the namespace does not exist, create a new dictionary for it
            namespaceIdToMarkerDict[_nameSpace] = new Dictionary<int, CustomMarker>();
        }

        // Check if the marker ID exists in the namespace
        if (!namespaceIdToMarkerDict[_nameSpace].ContainsKey(_id))
        {
            GameObject newMarkerObj = null;

            // Instantiate new object based on marker type
            if (_markerType == MarkerType.Cube)
            {
                newMarkerObj = Instantiate(markerCube, _position, _rotation);
            }
            else if (_markerType == MarkerType.Sphere)
            {
                newMarkerObj = Instantiate(markerSphere, _position, _rotation);
            }
            else if (_markerType == MarkerType.Cylinder)
            {
                newMarkerObj = Instantiate(markerCylinder, _position, _rotation);
            }
            else
            {
                Debug.LogWarning("UndefinedMarkerType:"+_markerType);
                return; // Exit the method if the marker type is undefined
            }
            CustomMarker newMarker = newMarkerObj.GetComponent<CustomMarker>();

            // Add the marker to the dictionary
            namespaceIdToMarkerDict[_nameSpace][_id] = newMarker;
            newMarker.nameSpace = _nameSpace;
            newMarker.id = _id;
            newMarker.markerType = _markerType;
            newMarker.position = _position;
            newMarker.rotation = _rotation;
            newMarker.scale = _scale;
            newMarker.color = _color;
            newMarker.UpdateObjPose();
            
        }
        else
        {
            namespaceIdToMarkerDict[_nameSpace][_id].position = _position;
            namespaceIdToMarkerDict[_nameSpace][_id].rotation = _rotation;
            namespaceIdToMarkerDict[_nameSpace][_id].scale = _scale;
            namespaceIdToMarkerDict[_nameSpace][_id].color = _color;
            namespaceIdToMarkerDict[_nameSpace][_id].UpdateObjPose();
            // Debug.LogWarning($"Marker with namespace {nameSpace} and ID {id} already exists.");
        }

    }


    public CustomMarker GetMarkerUsingNameSpaceId(string nameSpace, int id)
    {
        // Check if the namespace exists in the dictionary
        if (namespaceIdToMarkerDict.ContainsKey(nameSpace))
        {
            // Check if the marker ID exists within the namespace
            if (namespaceIdToMarkerDict[nameSpace].ContainsKey(id))
            {
                // Return the marker object
                return namespaceIdToMarkerDict[nameSpace][id];
            }
            else
            {
                Debug.LogWarning($"Marker with ID {id} not found in namespace {nameSpace}.");
            }
        }
        else
        {
            Debug.LogWarning($"Namespace {nameSpace} does not exist.");
        }

        // Return null if the marker is not found
        return null;
    }

    protected override void Awake()
    {
        base.Awake();
        if (!IsInitialized)
        {
            // Initialize your singleton instance here
        }
    }


    private void UpdateAllMarkerObjectPose()
    {
        foreach (var namespaceEntry in namespaceIdToMarkerDict)
        {
            string nameSpace = namespaceEntry.Key;
            Dictionary<int, CustomMarker> markerDict = namespaceEntry.Value;

            foreach (var markerEntry in markerDict)
            {
                int id = markerEntry.Key;
                CustomMarker marker = markerEntry.Value;

                // Perform some action with each marker
                marker.UpdateObjPose();
                // Debug.Log($"Namespace: {nameSpace}, ID: {id}, Marker Type: {marker.markerType}");
            }
        }
    }



    
}
