using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : RangedUnit
{
    public Fireball fireball;
    public Transform fireballSpawn;
    public AudioSource spellSound;

     public override void Start(){
        shootDelay = 0;
        base.Start();
    }
    public override void Shoot()
    {
        Debug.Log("Wizard shot a fireball");
        spellSound.Play();
        shootDelay = 5f;
        attackDelayVar = ATTACK_DELAY;
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", false);
        animator.SetTrigger("Shoot");
        Instantiate(fireball, fireballSpawn.position, Quaternion.identity);
    }

    public override bool CheckRange(){
        Collider[] EnemiesInRange = Physics.OverlapBox(rangeBox.transform.position, rangeBox.bounds.extents, Quaternion.identity, enemyLayers);
        Debug.Log("EnemiesInRange.Length = " + EnemiesInRange.Length);
        return(EnemiesInRange.Length != 0);
    }

   
}
