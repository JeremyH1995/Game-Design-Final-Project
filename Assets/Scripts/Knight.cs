using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : PlayerUnit
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
        this.stateChange(animator, speed);
    }

    void onCollisionEnter(Collision coll){
        Debug.Log("Collision Detected");
        animator.SetBool("isAttacking", true);
    }

}
