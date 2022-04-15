using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("EnemyUnit")){
            Debug.Log(this.name + " collided with " + coll.name);
            collidedWithEnemy = true;
        }
    }
}
