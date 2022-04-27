using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : Unit
{
    public AudioSource blockSound;
    public Text blockText;

    public override void Start(){
        blockText.gameObject.SetActive(false);
        base.Start();
    }
  public override void TakeDamage(int damage){
        if(BlockDamage()){
            Debug.Log("Knight blocked the attack");
            blockSound.Play();
            TurnOnText();
            damage = 0;
        }
        else{
            TurnOffText();
        }

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            Death();
        }
    }

    bool BlockDamage(){
        int rand = Random.Range(0, 9);
        return(rand >= 8);
    }

    void TurnOnText(){
        blockText.gameObject.SetActive(true);
    }

     void TurnOffText(){
        blockText.gameObject.SetActive(false);
    }
}
