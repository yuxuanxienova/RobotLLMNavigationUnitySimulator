using System;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static Vector3 VecRos2Unity(this Vector3 vector3_ros)
    {
        return new Vector3(-vector3_ros.y, vector3_ros.z, vector3_ros.x);
    }

    public static Vector3 VecUnity2Ros(this Vector3 vector3_unity)
    {
        return new Vector3(vector3_unity.z,-vector3_unity.x,vector3_unity.y);
    }
    public static Vector3 EulerRos2Unity(this Vector3 vector3_ros)
    {
        return new Vector3(vector3_ros.y, -vector3_ros.z, -vector3_ros.x);
    }

    public static Vector3 EulerUnity2Ros(this Vector3 vector3_unity)
    {
        return new Vector3(-vector3_unity.z,vector3_unity.x,-vector3_unity.y);
    }
    public static Quaternion QuaternionRos2Unity(this Quaternion qua_ros)
    {
        return new Quaternion(qua_ros.y, -qua_ros.z, -qua_ros.x, qua_ros.w);
    }

    public static Quaternion QuaternionUnity2Ros(this Quaternion qua_unity)
    {
        return new Quaternion(-qua_unity.z,qua_unity.x,-qua_unity.y,qua_unity.w);
    }


}
