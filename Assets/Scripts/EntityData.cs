using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Entity", menuName = "EntityData", order = 0)]
public class EntityData : ScriptableObject 
{
    public string entityName;
    public int maxHealth;

    public int maxEnrgy;

    public int attack;
    public int defense;

    public int speed;

    
}
