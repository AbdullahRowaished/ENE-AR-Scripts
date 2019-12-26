using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class for all GIS Features as per RFC 7946
/// </summary>
public class GIS_Feature
{
    public string featureName; //Human readable name for feature
    int identifier; //Numericle ID for feature
    /// <summary>
    /// Longitude and latitude for a Point
    /// </summary>
    public class Coordinates
    {
        private float longitude, latitude;

        public float Longitude { get => longitude; set => longitude = value; }
        public float Latitude { get => latitude; set => latitude = value; }
    }
    /// <summary>
    /// Point on map with coordinates and height above ground
    /// </summary>
    public class GIS_Point : GIS_Feature
    {
        public Coordinates coordinates;
        public float height;
    }
    /// <summary>
    /// Feature with many Points
    /// </summary>
    public class GIS_MultiPoint : GIS_Feature
    {
        public GIS_Point[] points;
    }
    /// <summary>
    /// Line on map made with Points
    /// </summary>
    public class GIS_LineString : GIS_Feature
    {
        public GIS_Point[] points;
    }
    /// <summary>
    /// Polygon made of Line Strings
    /// </summary>
    public class GIS_Polygon : GIS_Feature
    {
        public GIS_LineString[] linestrings;
    }
    /// <summary>
    /// Feature with many Polygons
    /// </summary>
    public class GIS_MultiPolygon : GIS_Feature
    {
        public GIS_Polygon[] polygons;
    }
    /// <summary>
    /// A collection containing several features
    /// </summary>
    public class GIS_GeometryCollection : GIS_Feature
    {
        public GIS_Feature[] geometries;
    }
}
