using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;

    private Transform target;
    private float maxSpeed;
    private float acceleration;
    private float currentSpeed = 0f;

    public void initializeProjectile(Transform target, float speed, float acceleration)
    {
        this.target = target;
        this.maxSpeed = speed;
        this.acceleration = acceleration;
    }

    /*
    Lifecycle methods
     */
    void Update()
    {
        if (target == null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            currentSpeed = Mathf.Min(maxSpeed, currentSpeed + acceleration * Time.deltaTime);
            Vector3 dir = target.position - transform.position;
            float deltaDistance = currentSpeed * Time.deltaTime;

            if (dir.magnitude <= deltaDistance)
            {
                GameObject impactFx = Instantiate(impactEffect, transform.position, transform.rotation);
                GameObject.Destroy(impactFx, 2f);
                GameObject.Destroy(gameObject);
            }
            else
            {
                transform.Translate(dir.normalized * deltaDistance, Space.World);
            }
        }
    }
}
