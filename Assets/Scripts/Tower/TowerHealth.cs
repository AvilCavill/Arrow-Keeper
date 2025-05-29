using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{

    public static TowerHealth Instance;
    public float maxHealth = 10;
    public float currentHealth;
    
    public Slider healthSlider;
    public TMP_Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }
    
    private void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateUI();
    }

    void UpdateUI()
    {
        // Actualizar Slider
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth; 
        }

        // Actualizar Text (opcional)
        if (healthText != null)
        {
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
    }
}
