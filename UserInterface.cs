using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    // GameObjects for UI Elements
    public GameObject Launch, Session; 

    // Start is called before the first frame update
    void Start()
    {
        Launch = GameObject.Find("LaunchScreen");
        Session = GameObject.Find("ARSession");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetStarted()
    {
        Launch.SetActive(false);
        Session.SetActive(true);
    }
}
