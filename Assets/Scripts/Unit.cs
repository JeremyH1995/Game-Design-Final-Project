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
    protected int currentHealth;
    public int maxHealth;
    public float speed;
    public int damage;
    public string enemyTag;
    public float ATTACK_DELAY;
    protected float attackDelayVar;
    protected float idleDelay;
    public bool isDead;
    public HealthBar healthBar;
    public int cost;
    

    public virtual void Start(){
        currentHealth = maxHealth;
        idleDelay = 0;
        attackDelayVar = 0;
        healthBar.SetMaxHealth(maxHealth);
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
            attackDelayVar -= Time.deltaTime;
            if(attackDelayVar <= 0){
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

    public virtual void Attack(){
        attackDelayVar = ATTACK_DELAY;

        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", false);

        //play attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(meleeAttackPoint.position, meleeRange, enemyLayers);

        if(hitEnemies.Length != 0){
            foreach(Collider enemy in hitEnemies){
                Unit enemyUnit = enemy.GetComponent<Unit>();
                if(enemyUnit != null){
                    if(enemyUnit.isDead == false){
                        enemyUnit.TakeDamage(damage);
                    }
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
