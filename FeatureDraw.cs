using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureDraw : MonoBehaviour
{
    [Tooltip("Database of Geometries")]
    public FeatureData features;

    [Tooltip("Fiber Cable Prefab")]
    public GameObject FiberPrefab;

    [Tooltip("Geolocation Script")]
    public Geolocation geolocation;

    

    public void DrawFeatures()
    {
        foreach (GIS_Feature feature in features.database.geometries)
        {
            if (feature is GIS_Feature.GIS_LineString)
            {

                GIS_Feature.GIS_LineString fiber_cable = (GIS_Feature.GIS_LineString) feature;
                GameObject cable = CreateFiberCable(fiber_cable.featureName, fiber_cable.points[0], geolocation);


                bool hasNearPoints = false; //Does this fiber cable fall within the 'goldilock zone'


                for (int i = 0; i < fiber_cable.points.Length - 1; i++)
                {
                    Debug.Log("Fiber Cable Points Length" + fiber_cable.points.Length);
                    Debug.Log("Loop Count: " + i);

                    GIS_Feature.GIS_Point firstPoint, secondPoint;
                    float length, angle; //length and angle between two points
                    float[] midpoint;

                    firstPoint = fiber_cable.points[i];
                    secondPoint = fiber_cable.points[i + 1];
                    
                    Debug.Log("First Point: " + firstPoint is null);
                    Debug.Log("Second Point: " + secondPoint is null);
                    Debug.Log("First Point Coords: " + firstPoint.coordinates is null);
                    Debug.Log("Second Point Coords: " + secondPoint.coordinates is null);
                    

                    length = EstimateLength(firstPoint.coordinates, secondPoint.coordinates);
                    midpoint = EstimateMidpoint(firstPoint.coordinates, secondPoint.coordinates);
                    angle = EstimateAngle(firstPoint.coordinates, secondPoint.coordinates);

                    if (length < 500f && !hasNearPoints) {
                        hasNearPoints = true;
                    }

                    CreateFiberSegment(midpoint, length, angle, cable, i+1);
                }

                if (!hasNearPoints)
                {
                    cable.SetActive(false);
                } else
                {
                    cable.SetActive(true);
                }
            }
        }
    }

    private float[] EstimateMidpoint(GIS_Feature.Coordinates coordinates1, GIS_Feature.Coordinates coordinates2)
    {
        //TODO reference midpoint (In GPS coordinates format) to User GPS location and convert to Unity units.
        return new float[] { (coordinates2.latitude + coordinates1.latitude) / 2, (coordinates2.longitude + coordinates1.longitude) / 2 };
    }

    /// <summary>
    /// Creates an empty object with the name 
    /// </summary>
    /// <param name="gIS_Point"></param>
    /// <param name="geolocation"></param>
    /// <returns></returns>
    private GameObject CreateFiberCable(string featureName, GIS_Feature.GIS_Point gIS_Point, Geolocation geolocation)
    {
        float y, x, a;
        y = (gIS_Point.coordinates.latitude - geolocation.latitude) * 111139;
        x = (gIS_Point.coordinates.longitude - geolocation.longitude) * 111139;
        a = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        Debug.Log("Mathf ATAN:" + a);

        GameObject cable = new GameObject(featureName);
        cable.transform.SetParent(transform);
        cable.transform.position = new Vector3(x, 0f, y);
        cable.transform.Rotate(Vector3.up*a);

        return cable;
    }

    private void CreateFiberSegment(float[] midpoint, float length, float angle, GameObject cable, int segmentNo)
    {
        Debug.Log("Mathf ATAN:" + angle);

        GameObject segment = Instantiate(FiberPrefab);

        segment.name = cable.name + ".Segment" + segmentNo;
        segment.transform.SetParent(cable.transform);

        segment.transform.position = new Vector3(midpoint[1], 0f, midpoint[0]);
        segment.transform.Rotate(Vector3.forward * angle);
        segment.transform.localScale += Vector3.up * length;

        
        segment.SetActive(true);

    }

    /// <summary>
    /// Uses pythagorean theory to determine length between two XY GIS_Points in planar space.
    /// </summary>
    /// <param name="coordinates1"></param>
    /// <param name="coordinates2"></param>
    /// <returns></returns>
    private float EstimateLength(GIS_Feature.Coordinates coordinates1, GIS_Feature.Coordinates coordinates2)
    {
        return 111139 * Mathf.Sqrt(Mathf.Pow(coordinates2.latitude - coordinates1.latitude, 2) + Mathf.Pow(coordinates2.longitude - coordinates1.longitude, 2));
    }
    /// <summary>
    /// Uses pythagorean theory to determine the angle between two XY GIS_Points in planar space
    /// </summary>
    /// <param name="coordinates1"></param>
    /// <param name="coordinates2"></param>
    /// <returns></returns>
    private float EstimateAngle(GIS_Feature.Coordinates coordinates1, GIS_Feature.Coordinates coordinates2)
    {
        return Mathf.Rad2Deg * Mathf.Atan2(coordinates2.latitude - coordinates1.latitude, coordinates2.longitude - coordinates1.longitude);
    }
}
