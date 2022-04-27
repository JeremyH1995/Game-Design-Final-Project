using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{  

    RangedUnit unit;
    public AudioSource soundSource;
    public LayerMask enemyLayers;
    public int magicDamage;
    public int speed;
    void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("EnemyUnit")){
        Debug.Log("Fireball collided with " + coll.name);
        soundSource.Play();
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, 1, enemyLayers);

            if(hitEnemies.Length != 0){
                foreach(Collider enemy in hitEnemies){
                    Unit enemyUnit = enemy.GetComponent<Unit>();
                    if(enemyUnit.isDead == false && enemyUnit != null){
                        enemyUnit.TakeDamage(magicDamage);
                    }   
                }  
            }
            Destroy(gameObject);
        }
    }

    void Update(){

       transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
       if(transform.position.x > 100){
           Destroy(gameObject);
       }
    }
}
