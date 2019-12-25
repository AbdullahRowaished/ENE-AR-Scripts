using GoogleARCore;
using UnityEngine;
using GoogleARCore.Examples.ObjectManipulation;

/// <summary>
/// Controls the placement of objects via a tap gesture.
/// </summary>
public class FiberManipulator : Manipulator
{
    /// <summary>
    /// The first-person camera being used to render the passthrough camera image (i.e. AR
    /// background).
    /// </summary>
    public Camera FirstPersonCamera;

    /// <summary>
    /// Manipulator prefab to attach placed objects to.
    /// </summary>
    public GameObject ManipulatorPrefab;

    /// <summary>
    /// Returns true if the manipulation can be started for the given gesture.
    /// </summary>
    /// <param name="gesture">The current gesture.</param>
    /// <returns>True if the manipulation can be started.</returns>
    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if (gesture.TargetObject == null)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Function called when the manipulation is ended.
    /// </summary>
    /// <param name="gesture">The current gesture.</param>
    protected override void OnEndManipulation(TapGesture gesture)
    {
        if (gesture.WasCancelled)
        {
            return;
        }

        // If gesture is targeting an existing object we are done.
        if (gesture.TargetObject == null)
        {
            return;
        } else
        {
            Manipulator manipulator = GetComponent<Manipulator>();

            Debug.Log("Targeted Object" + gesture.TargetObject.name);
            manipulator.Select();
        }
    }
}
