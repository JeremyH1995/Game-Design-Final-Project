using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    public override void Walk(float speed){
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("PlayerUnit")){
            Debug.Log(this.name + " collided with " + coll.name);
            collidedWithEnemy = true;
        }
    }
}
