using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public EntityData entityData;

    int health;
    int maxHealth;

    int enrgy;
    int maxEnrgy;

    int attack;
    int defense;

    int speed;

    private void Start() {
        health = entityData.maxHealth;
        maxHealth = entityData.maxHealth;

        enrgy = entityData.enrgy;
        maxEnrgy = entityData.maxEnrgy;

        attack = entityData.attack;
        defense = entityData.defense;

        speed = entityData.speed;

        Debug.Log("Entity " + entityData.entityName + " has been created!");
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log("Entity " + entityData.entityName + " has taken " + damage + " damage!");
        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        Debug.Log("Entity " + entityData.entityName + " has died!");
        Destroy(gameObject);
    }

}
