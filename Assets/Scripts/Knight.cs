using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Animator animator;

    private Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    //stats
    public float speed = 1.0f;
    public int health = 250;
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        //attackPoint = GameObject.Find("AttackPoint").transform;
        animator.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        stateChange();
    }

    void stateChange(){
        if(health <= 0){
            animator.SetTrigger("Death");
            Destroy(gameObject, 10);
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
