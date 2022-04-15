using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public bool collidedWithEnemy;
    public int currentHealth;
    public int maxHealth;
    public float speed;
    public HealthBar healthBar;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
   void Update()
    {
        stateChange();
    }

    public void stateChange(){
        if(currentHealth <= 0){
            animator.SetTrigger("Death");
            Destroy(gameObject, 10);
            CancelInvoke("stateChange");
        }
        else if(collidedWithEnemy){
            //set bool values
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", false);

            CancelInvoke("stateChange");
        }
        else if(animator.GetBool("isWalking") == true){
            Walk(speed);
        }
        else{
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
        }
    }

    public virtual void Walk(float speed){
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    public void Attack(){
        //play the attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //set damage to enemies
        foreach(Collider enemy in hitEnemies){
            Debug.Log("We hit " + enemy.name);
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Death(){
         //set bool values to false
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", false);

         //play death animation
        animator.SetTrigger("Death");
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator wait(int seconds){
        yield return new WaitForSeconds(seconds);
    }
}
