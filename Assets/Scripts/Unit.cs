using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    protected bool collidedWithEnemy;
    public int currentHealth;
    public int maxHealth;
    public float speed;
    public int damage;
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
        if(animator.GetBool("isWalking") == true){
            Walk(speed);
        }
        if(animator.GetBool("isIdle") == true){
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
        }
    }

    public virtual void Walk(float speed){
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    public void Attack(){
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", false);

        //play the attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //set damage to enemies
        foreach(Collider enemy in hitEnemies){
            enemy.GetComponent<EnemyUnit>().TakeDamage(damage);
            Debug.Log(enemy.name + " was hit!");
        }
       
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            animator.SetTrigger("Death");
            Destroy(gameObject, 10);
        }
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
