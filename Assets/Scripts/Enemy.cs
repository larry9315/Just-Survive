﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public Image healthBar;

    private float currentHealth;

    public GameObject enemeyDeathAnimation;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            GameObject obj = (GameObject)Instantiate(enemeyDeathAnimation, transform.position, Quaternion.identity);
            Destroy(obj, 5f);
            Destroy(gameObject);
            Score.incrementKill();
        }
    }

    public void HurtEnemy(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / health;
    }
}
