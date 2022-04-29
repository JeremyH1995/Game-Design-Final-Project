using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public EnemyHQ hq;

    void OnTriggerEnter(Collider coll){
        GameObject obj = coll.gameObject;
        if(coll.CompareTag("PlayerUnit")){
            hq.loseLife();
            Destroy(obj);
        }
    }
}
