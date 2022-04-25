using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Unit
{
    void OnTriggerEnter(Collider coll){
        if(coll.CompareTag(enemyTag)){
            Debug.Log(this.name + " collided with " + coll.name);
            collidedWithEnemy = true;
        }
    }
}
