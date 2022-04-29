using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{  

    RangedUnit unit;
    public GameObject explosionObj;
    Explosion explosion;
    public AudioSource explosionSound;
    public LayerMask enemyLayers;
    public int magicDamage;
    public int speed;

    void Start(){
        explosion = explosionObj.GetComponent<Explosion>();
    }
    void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("EnemyUnit")){
        Debug.Log("Fireball collided with " + coll.name);
        speed = 0;
        Instantiate(explosionObj, transform);
        explosion.Play();
        explosionSound.Play();
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, 1, enemyLayers);

            if(hitEnemies.Length != 0){
                foreach(Collider enemy in hitEnemies){
                    Unit enemyUnit = enemy.GetComponent<Unit>();
                    if(enemyUnit.isDead == false && enemyUnit != null){
                        enemyUnit.TakeDamage(magicDamage);
                    }   
                }  
            }
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }

    void Update(){

       transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
       if(transform.position.x > 100){
           Destroy(gameObject);
       }
    }
}
