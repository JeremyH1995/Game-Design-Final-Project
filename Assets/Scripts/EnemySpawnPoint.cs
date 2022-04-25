using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public EnemyHQ hq;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll){
        GameObject obj = coll.gameObject;
        if(coll.CompareTag("PlayerUnit")){
            hq.loseLife();
            Destroy(obj);
        }
    }
}
