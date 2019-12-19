using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentPooling : MonoBehaviour
{
    private Stack<GameObject> segmentPool { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        segmentPool = PreparePool();
    }
    /// <summary>
    /// Prepares pool of fiber cable segments
    /// </summary>
    /// <returns>Stack of all GameObjects in scene with tag Segment</returns>
    private Stack<GameObject> PreparePool()
    {
        Stack<GameObject> pool = new Stack<GameObject>(GameObject.FindGameObjectsWithTag("Segment"));
        foreach(GameObject segment in pool)
        {
            segment.SetActive(false);
        }
        return pool;
    }
    /// <summary>
    /// Get one fiber cable segment from pool
    /// </summary>
    /// <returns>Game Object with tag Segment</returns>
    public GameObject PoolSegment()
    {
        GameObject segment = segmentPool.Pop();
        segment.SetActive(true);

        return segment;
    }
    /// <summary>
    /// Returns one GameObject back into the pool and cleans up its Transform's position and rotation
    /// </summary>
    /// <param name="segment">If the parameter has a tag of Segment, it enters the pool</param>
    public void ReturnToPool(GameObject segment)
    {
        if (segment.CompareTag("Segment"))
        {
            segmentPool.Push(segment);
            segment.transform.position = Vector3.zero;
            segment.transform.rotation = Quaternion.Euler(0, 0, 0);
            segment.transform.parent = transform;
        }
    }
}
