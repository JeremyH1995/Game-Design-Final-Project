using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Characters/Zombie/Animations/Zombie");
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("isWalking") == false && animator.GetBool("isDead") == false && animator.GetBool("isAttacking") == false){
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
