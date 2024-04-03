using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 10f;
    
    [HideInInspector]
    public float speed;
    
    public float health = 100;
    public int value = 50; // how much money it gives you
    public GameObject deathEffect;

    private void Start()
    {
        speed = baseSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = baseSpeed * amount;
    }

    void Die()
    {
        PlayerStats.Money += value;
        
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    
}
