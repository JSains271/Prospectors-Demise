using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : CoreComponent
{
    public event Action OnHealthZero;

    [SerializeField] private int maxHealth;
    public int currentHealth;

    public Slider healthBar;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;

        healthBar.value = currentHealth;

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