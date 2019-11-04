using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    public TargetTracking tracker;

    public float attackRate = 1f;
    private float attackDelay = 0f;

    public Transform attackLaunchPoint;
    public GameObject projectile;

    public float projectileSpeed = 100f;
    public float projectileAcceleration = 100f;

    void initiateAttack(Transform target)
    {
        GameObject projectileObject = Instantiate(projectile, attackLaunchPoint.position, attackLaunchPoint.rotation);
        Projectile projectileScript = projectileObject.GetComponent<Projectile>();
        if (projectileScript != null)
            projectileScript.initializeProjectile(target, projectileSpeed, projectileAcceleration);
    }

    /*
    Lifecyle methods
     */
    void Update()
    {
        Transform target = tracker.getTarget();
        if (target == null) return;

        if (attackDelay <= 0f)
        {
            initiateAttack(target);
            attackDelay = 1f / attackRate;
        }
        attackDelay -= Time.deltaTime;
    }
}
