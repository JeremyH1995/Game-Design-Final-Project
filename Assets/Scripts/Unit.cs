using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Animator animator;
    public Transform meleeAttackPoint;
    public float meleeRange;
    public LayerMask enemyLayers;
    public bool collidedWithEnemy;
    public int currentHealth;
    public int maxHealth;
    public float speed;
    public int damage;
    public string enemyTag;
    protected float attackDelay;
    protected float idleDelay;
    public bool isDead;
    public HealthBar healthBar;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        attackDelay = 0;
        idleDelay = 0;
        isDead = false;
        animator.SetBool("isIdle", true);
    }
   void Update()
    {
        stateChange();
    }

    public virtual void stateChange(){
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

    public void Walk(float speed){
        if(gameObject.tag == "PlayerUnit"){
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if(gameObject.tag == "EnemyUnit"){
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        
    }

    protected bool CheckAttack(){
        Collider[] EnemiesInRange = Physics.OverlapSphere(meleeAttackPoint.position, meleeRange, enemyLayers);
        return (EnemiesInRange.Length != 0);
    }

    public void Attack(){
        attackDelay = 3f;

        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", false);

        //play attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(meleeAttackPoint.position, meleeRange, enemyLayers);

        if(hitEnemies.Length != 0){
            foreach(Collider enemy in hitEnemies){
                Unit enemyUnit = enemy.GetComponent<Unit>();
                if(enemyUnit.isDead == false && enemyUnit != null){
                    enemyUnit.TakeDamage(damage);
                }   
            }  
        }
        else{
            collidedWithEnemy = false;
            animator.SetBool("isIdle", true);
        }
        
    }

     void OnTriggerEnter(Collider coll){
        if(coll.CompareTag(enemyTag)){
            Debug.Log(this.name + " collided with " + coll.name);
            collidedWithEnemy = true;
        }
    }
    public virtual void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            Death();
        }
    }

    public void Death(){
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

    public virtual void OnDrawGizmosSelected(){
        if(meleeAttackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(meleeAttackPoint.position, meleeRange);
    }
}
