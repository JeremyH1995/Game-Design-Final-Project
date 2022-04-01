using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : EnemyUnit
{
    Animator animator;
    //stats
    float speed = 1.0f;
    int health = 100;
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
}
