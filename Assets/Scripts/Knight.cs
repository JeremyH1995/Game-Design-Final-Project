using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MeleeUnit
{
  public override void TakeDamage(int damage){
        
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            Death();
        }
    }
}
