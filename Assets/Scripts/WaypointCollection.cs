using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCollection : MonoBehaviour
{
    public Transform waypointParent;
    private Transform[] waypointCollection;

    public Transform[] getWaypoints()
    {
        return waypointCollection;
    }

    /*
    Lifecycle methods
     */
    void Awake()
    {
        if (waypointParent != null)
        {
            waypointCollection = new Transform[waypointParent.childCount];
            for (int i = 0; i < waypointCollection.Length; i++)
            {
                waypointCollection[i] = waypointParent.GetChild(i);
            }
        }
    }
}
