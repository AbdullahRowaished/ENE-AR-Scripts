using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class for all GIS Features as per RFC 7946
/// </summary>
public class GIS_Feature : MonoBehaviour
{
    string featureName; //Human readable name for feature
    int identifier; //Numericle ID for feature
    /// <summary>
    /// Longitude and latitude for a Point
    /// </summary>
    internal class Coordinates
    {
        float longitude, latitude;
    }
    /// <summary>
    /// Point on map with coordinates and height above ground
    /// </summary>
    internal class GIS_Point : GIS_Feature
    {
        Coordinates coordinates;
        float height;
    }
    /// <summary>
    /// Feature with many Points
    /// </summary>
    internal class GIS_MultiPoint : GIS_Feature
    {
        GIS_Point[] points;
    }
    /// <summary>
    /// Line on map made with Points
    /// </summary>
    internal class GIS_LineString : GIS_Feature
    {
        GIS_Point[] points;
    }
    /// <summary>
    /// Polygon made of Line Strings
    /// </summary>
    internal class GIS_Polygon : GIS_Feature
    {
        GIS_LineString[] linestrings;
    }
    /// <summary>
    /// Feature with many Polygons
    /// </summary>
    internal class GIS_MultiPolygon : GIS_Feature
    {
        GIS_Polygon[] polygons;
    }
    /// <summary>
    /// A collection containing several features
    /// </summary>
    internal class GIS_GeometryCollection : GIS_Feature
    {
        GIS_Feature[] geometries;
    }
}
