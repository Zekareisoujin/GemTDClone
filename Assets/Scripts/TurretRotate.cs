using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    public TargetTracking tracker;
    public Transform turretHead;
    public float angularTurnRate = 10f;

    /*
    Lifecycle methods
     */
    void Update()
    {
        Transform target = tracker.getTarget();
        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        Vector3 rotation = Quaternion.Lerp(turretHead.rotation, Quaternion.LookRotation(dir), Time.deltaTime * angularTurnRate).eulerAngles;
        turretHead.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
