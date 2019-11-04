using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracking : MonoBehaviour
{
    public Transform target;
    public float range = 10f;
    public string targetTag = "Enemy";

    private float targetScanInterval = 0.5f;

    public Transform getTarget()
    {
        return target;
    }

    void ScanForTarget()
    {
        // Only scan for new targets if there is no current target
        if (target != null) return;

        GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject nearestTarget = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject candidate in potentialTargets)
        {
            float dist = Vector3.Distance(transform.position, candidate.transform.position);
            if (dist < shortestDistance)
            {
                shortestDistance = dist;
                nearestTarget = candidate;
            }
        }

        if (nearestTarget != null && shortestDistance <= range)
        {
            target = nearestTarget.transform;
        }
    }

    /*
    Lifecyle methods
     */
    void Start()
    {
        InvokeRepeating("ScanForTarget", 0f, targetScanInterval);
    }

    void Update()
    {
        // Remove current target when it's out of range
        if (target != null && Vector3.Distance(transform.position, target.position) > range)
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
