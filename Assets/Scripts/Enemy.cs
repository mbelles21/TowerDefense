 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 10f;
    
    [HideInInspector]
    public float speed;
    private float health;
    
    public float startHealth = 100;
    
    
    public int value = 50; // how much money it gives you
    public GameObject deathEffect;

    [Header("Unity Stuff")] 
    public Image healthBar;


    private bool isDead = false;
    
    private void Start()
    {
        speed = baseSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
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
        isDead = true;
        
        PlayerStats.Money += value;
        
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);
    }

    
}
