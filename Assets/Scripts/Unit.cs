using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Animator animator;
    private Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int currentHealth;
    public int maxHealth;
    public float speed;
    public bool isPlayerUnit;
    public bool isEnemyUnit;
    public HealthBar healthBar;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
   void Update()
    {
        stateChange();
    }

    void stateChange(){
        if(currentHealth <= 0){
            animator.SetTrigger("Death");
            Destroy(gameObject, 10);
            CancelInvoke("stateChange");
        }
        else if(animator.GetBool("isIdle") == true){
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
        }
        else if(animator.GetBool("isWalking") == true){
            Walk(speed);
        }
        
    }

    void Attack(){
        //set bool values to false
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", false);

        //play attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //set damage to enemies
        foreach(Collider enemy in hitEnemies){
            Debug.Log("We hit " + enemy.name);
        }
    }

    void Walk(float speed){
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
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
}
