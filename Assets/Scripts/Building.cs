using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
     public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
