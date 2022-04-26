using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abomination : Unit
{
    public int healAmount = 5; 
    float nextActionTime = 0.0f;
    float period = 1f;
    //Abomination heals when not in combat
    void Update(){
        stateChange();
        if(Time.time > nextActionTime){
            nextActionTime = Time.time + period;
            if(collidedWithEnemy == false){
                if(currentHealth < maxHealth){
                    Heal(healAmount);
                }
            }
        }
    }

    void Heal(int amount){
        currentHealth += amount;
        healthBar.SetHealth(currentHealth);
    }
}
