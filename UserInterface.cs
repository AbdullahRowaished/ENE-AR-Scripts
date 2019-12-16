using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    // GameObjects for UI Elements
    [Tooltip("Input UI Elements")]
    public GameObject Launch, Session;
    public Text GPS;

    /// <summary>
    /// Switches from Launch Screen to AR Session
    /// </summary>
    public void GetStarted()
    {
        Launch.SetActive(false);
        Session.SetActive(true);
    }

    /// <summary>
    /// Updates GPS Coordinates
    /// </summary>
    /// <param name="coordinates"></param>
    public void UpdateGPS(string coordinates)
    {
        GPS.text = "Location: " + coordinates;
    }
}
