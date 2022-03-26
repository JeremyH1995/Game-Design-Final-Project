using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("Assets/Characters/Knight/animations/KnightController"));
        Debug.Log(animator.runtimeAnimatorController.name);
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
