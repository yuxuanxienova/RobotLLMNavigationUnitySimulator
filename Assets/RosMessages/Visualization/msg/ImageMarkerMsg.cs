//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.BuiltinInterfaces;

namespace RosMessageTypes.Visualization
{
    [Serializable]
    public class ImageMarkerMsg : Message
    {
        public const string k_RosMessageName = "visualization_msgs/ImageMarker";
        public override string RosMessageName => k_RosMessageName;

        public const byte CIRCLE = 0;
        public const byte LINE_STRIP = 1;
        public const byte LINE_LIST = 2;
        public const byte POLYGON = 3;
        public const byte POINTS = 4;
        public const byte ADD = 0;
        public const byte REMOVE = 1;
        public HeaderMsg header;
        public string ns;
        //  namespace, used with id to form a unique id
        public int id;
        //  unique id within the namespace
        public int type;
        //  CIRCLE/LINE_STRIP/etc.
        public int action;
        //  ADD/REMOVE
        public Geometry.PointMsg position;
        //  2D, in pixel-coords
        public float scale;
        //  the diameter for a circle, etc.
        public Std.ColorRGBAMsg outline_color;
        public byte filled;
        //  whether to fill in the shape with color
        public Std.ColorRGBAMsg fill_color;
        //  color [0.0-1.0]
        public DurationMsg lifetime;
        //  How long the object should last before being automatically deleted.  0 means forever
        public Geometry.PointMsg[] points;
        //  used for LINE_STRIP/LINE_LIST/POINTS/etc., 2D in pixel coords
        public Std.ColorRGBAMsg[] outline_colors;
        //  a color for each line, point, etc.

        public ImageMarkerMsg()
        {
            this.header = new HeaderMsg();
            this.ns = "";
            this.id = 0;
            this.type = 0;
            this.action = 0;
            this.position = new Geometry.PointMsg();
            this.scale = 0.0f;
            this.outline_color = new Std.ColorRGBAMsg();
            this.filled = 0;
            this.fill_color = new Std.ColorRGBAMsg();
            this.lifetime = new DurationMsg();
            this.points = new Geometry.PointMsg[0];
            this.outline_colors = new Std.ColorRGBAMsg[0];
        }

        public ImageMarkerMsg(HeaderMsg header, string ns, int id, int type, int action, Geometry.PointMsg position, float scale, Std.ColorRGBAMsg outline_color, byte filled, Std.ColorRGBAMsg fill_color, DurationMsg lifetime, Geometry.PointMsg[] points, Std.ColorRGBAMsg[] outline_colors)
        {
            this.header = header;
            this.ns = ns;
            this.id = id;
            this.type = type;
            this.action = action;
            this.position = position;
            this.scale = scale;
            this.outline_color = outline_color;
            this.filled = filled;
            this.fill_color = fill_color;
            this.lifetime = lifetime;
            this.points = points;
            this.outline_colors = outline_colors;
        }

        public static ImageMarkerMsg Deserialize(MessageDeserializer deserializer) => new ImageMarkerMsg(deserializer);

        private ImageMarkerMsg(MessageDeserializer deserializer)
        {
            this.header = HeaderMsg.Deserialize(deserializer);
            deserializer.Read(out this.ns);
            deserializer.Read(out this.id);
            deserializer.Read(out this.type);
            deserializer.Read(out this.action);
            this.position = Geometry.PointMsg.Deserialize(deserializer);
            deserializer.Read(out this.scale);
            this.outline_color = Std.ColorRGBAMsg.Deserialize(deserializer);
            deserializer.Read(out this.filled);
            this.fill_color = Std.ColorRGBAMsg.Deserialize(deserializer);
            this.lifetime = DurationMsg.Deserialize(deserializer);
            deserializer.Read(out this.points, Geometry.PointMsg.Deserialize, deserializer.ReadLength());
            deserializer.Read(out this.outline_colors, Std.ColorRGBAMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.ns);
            serializer.Write(this.id);
            serializer.Write(this.type);
            serializer.Write(this.action);
            serializer.Write(this.position);
            serializer.Write(this.scale);
            serializer.Write(this.outline_color);
            serializer.Write(this.filled);
            serializer.Write(this.fill_color);
            serializer.Write(this.lifetime);
            serializer.WriteLength(this.points);
            serializer.Write(this.points);
            serializer.WriteLength(this.outline_colors);
            serializer.Write(this.outline_colors);
        }

        public override string ToString()
        {
            return "ImageMarkerMsg: " +
            "\nheader: " + header.ToString() +
            "\nns: " + ns.ToString() +
            "\nid: " + id.ToString() +
            "\ntype: " + type.ToString() +
            "\naction: " + action.ToString() +
            "\nposition: " + position.ToString() +
            "\nscale: " + scale.ToString() +
            "\noutline_color: " + outline_color.ToString() +
            "\nfilled: " + filled.ToString() +
            "\nfill_color: " + fill_color.ToString() +
            "\nlifetime: " + lifetime.ToString() +
            "\npoints: " + System.String.Join(", ", points.ToList()) +
            "\noutline_colors: " + System.String.Join(", ", outline_colors.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
