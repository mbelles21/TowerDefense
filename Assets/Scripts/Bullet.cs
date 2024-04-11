using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cinemachine;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damage = 50;
    public float blastZone = 0f;
    public GameObject impactEffect;
    
    // for cinemachine
    // public CameraShake cameraShake;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(direction.normalized * distThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        // cameraShake.ScreenShake();
        
        GameObject effectInst = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 5f);

        if (blastZone > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        
        Destroy(gameObject);
    }

    // check for blast damage from missiles
    void Explode()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, blastZone);
        foreach (var collider in collisions)
        {
            if (collider.tag == "enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    // draw missile explosion area
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastZone);
    }
}
