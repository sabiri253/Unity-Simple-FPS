using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Bullet bullet;
    public HealthScript health;
    public float healthValue = 20;
    public bool damaged = false;
     void Start()
    {
        bullet = FindObjectOfType<Bullet>();
        health.healthBar.maxValue = healthValue;
        health.healthBar.value = healthValue;
        health.currValue = healthValue;
    }

    // Update is called once per frame
    void Update(){
        if (bullet.hitEnemy)
            TakeDamage(1);
        health.healthBar.value = healthValue;
    }

    void TakeDamage(float damage){
        healthValue -= damage;
    }

}