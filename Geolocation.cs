using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Geolocation : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
        LocationInit();
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
            print("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            GameObject feat;
            feat = GameObject.Find("Feature Details");
            feat.GetComponent<Text>().text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
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

