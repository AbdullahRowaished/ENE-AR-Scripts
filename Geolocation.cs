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
