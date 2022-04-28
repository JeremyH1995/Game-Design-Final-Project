using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeArea : MonoBehaviour
{
    public RangedUnit unit;

    void Start(){
        unit = gameObject.GetComponentInParent<RangedUnit>();
        Debug.Log("RangeArea unit is " + unit.name);
    }
   void OnTriggerEnter(Collider coll){
       if(coll.CompareTag("EnemyUnit")){
            Debug.Log(this.name + " collided with " + coll.name);
            unit.rangeCollidedWithEnemy = true;
        }
   }

}
