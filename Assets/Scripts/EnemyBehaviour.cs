using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;

    private Transform[] waypointCollection;
    private int currentIndex;

    public static float samePositionThreshold = 1f;

    /* 
    Lifecycle methods
     */
    void Start()
    {
        WaypointCollection wps = (WaypointCollection)gameObject.GetComponent("WaypointCollection");
        if (wps.getWaypoints() != null)
        {
            waypointCollection = wps.getWaypoints();
            currentIndex = 0;
        }
    }

    void Update()
    {
        if (waypointCollection == null || currentIndex >= waypointCollection.Length)
        {
            Destroy(gameObject);
        }
        else
        {
            Transform target = waypointCollection[currentIndex];
            if (Vector3.Distance(transform.position, target.position) <= samePositionThreshold)
            {
                currentIndex++;
            }
            else
            {
                agent.SetDestination(target.position);
            }
        }
    }
}
