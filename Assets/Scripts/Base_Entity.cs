using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Entity : MonoBehaviour
{
    public EntityData entityData;
    private HealthSystem healthSystem;

    // Other code for your entity here

    private void Start()
    {
        // Get the HealthSystem component attached to the same GameObject
        healthSystem = GetComponent<HealthSystem>();

        // Check if the reference is not null and set the maximum health
        if (healthSystem != null && entityData != null)
        {
            healthSystem.SetMaxHealth(entityData.maxHealth);
        }
        else
        {
            Debug.LogError("HealthSystem or EntityData not properly assigned.");
        }
    }
}
