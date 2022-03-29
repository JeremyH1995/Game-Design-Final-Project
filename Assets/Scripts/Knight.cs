using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Animator animator;
    //stats
    float speed = 1.0f;
    int health = 250;
    int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("isWalking") == true){
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if(animator.GetBool("isWalking") == false && animator.GetBool("isDead") == false && animator.GetBool("isAttacking") == false){
            animator.SetBool("isWalking", true);
        }
    }

    void onCollisionEnter(Collision coll){
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "EnemyUnit"){
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
        }
    }
}
