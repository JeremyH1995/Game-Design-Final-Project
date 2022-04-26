using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int arrowDamage;
    public int speed;
    void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("EnemyUnit")){
            Destroy(gameObject);
            Unit enemy = coll.GetComponent<Unit>();
            enemy.TakeDamage(arrowDamage);
        }
    }

    void Update(){
       transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
       if(transform.position.x > 100){
           Destroy(gameObject);
       }
    }
}
