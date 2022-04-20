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
    float attackDelay;
    float idleDelay;
    public float damageTime;
    public bool isDead;
    public HealthBar healthBar;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        attackDelay = 0;
        idleDelay = 0;
        isDead = false;
    }
   void Update()
    {
        stateChange();
    }

    public void stateChange(){
        if(isDead == true){
            //do nothing until deletion
        }
        else if(collidedWithEnemy == true){
            attackDelay -= Time.deltaTime;
            if(attackDelay <= 0){
                if(CheckAttack()){
                    Attack();
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

    public virtual void Walk(float speed){
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    bool CheckAttack(){
        Collider[] EnemiesInRange = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        return (EnemiesInRange.Length != 0);
    }

    public void Attack(){
        attackDelay = 3f;

        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", false);

        //play attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        if(hitEnemies.Length != 0){
            foreach(Collider enemy in hitEnemies){
            Unit enemyUnit = enemy.GetComponent<Unit>();
            enemyUnit.TakeDamage(damage);
            Debug.Log(enemy.name + " was hit!");
                if(enemyUnit.isDead == true){
                    Debug.Log(enemyUnit.name + " is dead!");
                }
            }  
        }
        else{
            collidedWithEnemy = false;
            animator.SetBool("isIdle", true);
        }
        
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            Death();
        }
    }

    void Death(){
        //set bool values to false
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", false);

        isDead = true;
        GetComponent<BoxCollider>().enabled = false;

        //play death animation
        animator.SetTrigger("Death");

        //delete game object
        Destroy(gameObject, 5);
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
