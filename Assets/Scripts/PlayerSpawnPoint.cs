using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public HQ hq;

    void OnTriggerEnter(Collider coll){
        //GameObject obj = coll.gameObject;
        if(coll.CompareTag("EnemyUnit")){
            hq.loseLife();
            Destroy(coll.gameObject);
        }
    }
}
