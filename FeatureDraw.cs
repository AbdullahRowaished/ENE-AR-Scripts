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
    // Start is called before the first frame update
    

    public void DrawFeatures()
    {
        foreach (GIS_Feature feature in features.database.geometries)
        {
            if (feature is GIS_Feature.GIS_LineString)
            {

                GIS_Feature.GIS_LineString fiber_cable = ((GIS_Feature.GIS_LineString) feature);

                for (int i = 0; i < fiber_cable.points.Length - 1; i++)
                {
                    GIS_Feature.GIS_Point firstPoint, secondPoint;

                    firstPoint = ((GIS_Feature.GIS_Point)fiber_cable.points[i]);
                    secondPoint = ((GIS_Feature.GIS_Point)fiber_cable.points[i+1]);

                    //TODO
                }
            }
        }
    }

}
