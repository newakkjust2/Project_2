using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Slider healthBar;
    
    public float currentHealth;
    public float CurrentHealth => currentHealth;
    private AllVariantsItemSO collection;
    

    private void Start()
    {
        currentHealth = 50;
        healthBar.minValue = 0f;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        healthBar.value = currentHealth;
    }

    public void TakeAwayHealth(float amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;
    }
}
