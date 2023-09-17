using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth;

    // Other health-related methods and properties
    void Start()
    {
        Debug.Log(name + " has " + currentHealth);
    }
    public void SetMaxHealth(int maxHealthValue)
    {
        maxHealth = maxHealthValue;
        currentHealth = maxHealth; // Set the current health to the maximum when initializing.
    }
}
