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
        if(animator.GetBool("isWalking") == true){
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if(animator.GetBool("isWalking") == false && animator.GetBool("isDead") == false && animator.GetBool("isAttacking") == false){
            animator.SetBool("isWalking", true);
        }
    }

    void onCollisionEnter(Collision coll){
       
    }
}
