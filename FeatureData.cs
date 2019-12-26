using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureData : MonoBehaviour
{
    public GIS_Feature.GIS_GeometryCollection database;
    // Start is called before the first frame update
    void Start()
    {
        PopulateDatabase();
    }

    void PopulateDatabase()
    {
        database = new GIS_Feature.GIS_GeometryCollection();
        database.featureName = "Database";
        database.geometries = new GIS_Feature[1];
        database.geometries[0] = new GIS_Feature.GIS_LineString();
        database.geometries[0].featureName = "FOCAbbas";
        
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points = new GIS_Feature.GIS_Point[4];
        
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[0] = new GIS_Feature.GIS_Point();
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[0].coordinates = new GIS_Feature.Coordinates();
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[0].coordinates.latitude = 26.32996f;
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[0].coordinates.longitude = 50.10927f;
        
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[1] = new GIS_Feature.GIS_Point();
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[1].coordinates = new GIS_Feature.Coordinates();
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[1].coordinates.latitude = 26.32999f;
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[1].coordinates.longitude = 50.10926f;

        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[2] = new GIS_Feature.GIS_Point();
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[2].coordinates = new GIS_Feature.Coordinates();
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[2].coordinates.latitude = 26.32986f;
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[2].coordinates.longitude = 50.10916f;

        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[3] = new GIS_Feature.GIS_Point();
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[3].coordinates = new GIS_Feature.Coordinates();
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[3].coordinates.latitude = 26.32983f;
        ((GIS_Feature.GIS_LineString)database.geometries[0]).points[3].coordinates.longitude = 50.10917f;
    }
}
