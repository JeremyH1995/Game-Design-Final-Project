using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedUnit : Unit
{
    public bool rangeCollidedWithEnemy;
    public float shootDelay;
    public Transform RangeBox;
   
    public override void stateChange(){
        if(isDead == true){
            //do nothing until deletion
        }
        else if(collidedWithEnemy == true){
            attackDelay -= Time.deltaTime;
            if(attackDelay <= 0){
                if(CheckAttack()){
                    Attack();
                }
                else{
                    collidedWithEnemy = false;
                    animator.SetBool("isIdle", true);
                }
            }   
        }
        else if(rangeCollidedWithEnemy == true){
            shootDelay -= Time.deltaTime;
            if(shootDelay <= 0){
                if(CheckRange()){
                    Shoot();
                }
                else{
                    rangeCollidedWithEnemy = false;
                    animator.SetBool("isIdle", true);
                }    
            }
        }
        else if(animator.GetBool("isWalking") == true){
            Walk(speed);
        }
        else if(animator.GetBool("isIdle") == true){
            idleDelay -= Time.deltaTime;
            if(idleDelay <= 0){
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalking", true);
            }
        }
    }

    public virtual void Shoot(){
       //shoot enemy
    }

    public bool CheckRange(){
        Collider[] EnemiesInRange = Physics.OverlapBox(RangeBox.position, RangeBox.localScale);
        return(EnemiesInRange.Length != 0);
    }

    public override void OnDrawGizmosSelected(){
        if(meleeAttackPoint == null)
            return;
        if(RangeBox == null)
            return;
        
        Gizmos.DrawWireSphere(meleeAttackPoint.position, meleeRange);
        Gizmos.DrawWireCube(RangeBox.position, RangeBox.localScale);
    }
}
