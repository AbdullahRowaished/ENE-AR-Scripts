using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Geolocation : MonoBehaviour
{
    UnityEngine.UI.Text text;
    IEnumerator RV;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        text = GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>();
        RV = LocationInit();
        return RV;
    }


    private IEnumerator LocationInit()
    {
        if(!Input.location.isEnabledByUser) {
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            text.text = "Timed out";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            text.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            text.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
        }

        Input.location.Stop();
    }
   
    

}

/// <summary>
/// Abstract class for all GIS Features as per RFC 7946
/// </summary>
internal abstract class GIS_Feature
{
    string name; //Human readable name for feature
    int identifier; //Numericle ID for feature
}
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

