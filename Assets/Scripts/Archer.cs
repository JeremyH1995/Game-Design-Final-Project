using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : RangedUnit
{
    public Arrow arrow;

    public override void Shoot()
    {
        Debug.Log("Archer took a shot");
        shootDelay = 3f;
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", false);
        animator.SetTrigger("Shoot");
        Instantiate(arrow, meleeAttackPoint.transform.position, Quaternion.Euler(0, 90, 0));
    }

}
