using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    public event Action OnHealthZero;

    [SerializeField] private int maxHealth;
    private int currentHealth;

    public HealthBar healthBar;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            OnHealthZero.Invoke();

            Debug.Log("Health is zero!!");
        }
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}