using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("isIdle") == true){
            animator.SetBool("isIdle", false);
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
