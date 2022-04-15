using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHQ : MonoBehaviour
{
    //Spawn Info
    GameObject spawnPoint;
    public Vector3 spawnPos;
    public Quaternion rotation = Quaternion.Euler(0, -90, 0);

    //Unit Objects
    public GameObject zombiePrefab;
    public GameObject goblinPrefab;
    public GameObject abominationPrefab;
    public EnemyGoldMine goldMine;

    //Unit Prices
    int zombiePrice = 20;
    int goblinPrice = 30;
    int abominationPrice = 50;

    //HQ Properties
    public int health = 1000;

    // Start is called before the first frame update
    void Start()
    {
        //get spawnpoint
        spawnPoint = GameObject.Find("EnemySpawnPoint");
        spawnPos = spawnPoint.transform.position;
        
        //call RollForUnit reapeatedly
        InvokeRepeating("Decide", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            death();
        }
    }

    void Decide(){
        int value = RollForUnit();
        switch(value){
            case 0: 
                spawnZombie();
                break;
            case 1: 
                spawnGoblin();
                break;
            case 2: 
                spawnAbomination();
                break;
            case 3: 
                goldMine.upgrade();
                break;
        }
    }
    
    int RollForUnit(){
        /*random number sheet 
        0 - Zombie
        1 - Goblin
        2 - Abomination
        3 - upgrade Goldmine
        */
        return Random.Range(0, 3);
    }

    void death(){
        CancelInvoke();

    }

    void spawnZombie()
    {
        if(goldMine.getGold() > zombiePrice){
            goldMine.buyUnit(zombiePrice);
            GameObject zombie = Instantiate<GameObject>(zombiePrefab, spawnPos, rotation);
        }
            
    }

    void spawnAbomination(){
        if(goldMine.getGold() > abominationPrice){
            goldMine.buyUnit(abominationPrice);
            GameObject abomination = Instantiate<GameObject>(abominationPrefab, spawnPos, rotation);
        }
            
    }

    void spawnGoblin(){
        if(goldMine.getGold() > goblinPrice){
            goldMine.buyUnit(goblinPrice);
            GameObject goblin = Instantiate<GameObject>(goblinPrefab, spawnPos, rotation);
        }
    }
}