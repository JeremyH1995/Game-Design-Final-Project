using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void stateChange(Animator animator, float speed){
        if(animator.GetBool("isIdle") == true){
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
        }
       // else if(){
            //check when to attack
        //}
        else if(animator.GetBool("isWalking") == true){
            Walk(speed);
        }
        
    }

    void Attack(Animator animator){
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", false);
        animator.SetTrigger("Attack");
    }

    void Walk(float speed){
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    void onCollisionEnter(Collision coll){
       
    }
}
