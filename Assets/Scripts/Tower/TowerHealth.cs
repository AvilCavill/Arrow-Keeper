using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{

    public static TowerHealth Instance;
    public float maxHealth = 10;
    public float currentHealth;
    
    public Slider healthSlider;
    public Text healthText;

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
        maxHealth -= damage;
        if (maxHealth <= 0)
        {
            Debug.Log("La torre ha caido!");
        }
        {
            
        }
    }
    
    void UpdateUI()
    {
        // Actualizar Slider
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth; // Normalizado (0-1)
        }

        // Actualizar Text (opcional)
        if (healthText != null)
        {
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
    }
}
