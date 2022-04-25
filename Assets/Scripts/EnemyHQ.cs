using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHQ : MonoBehaviour
{
    //Spawn Info
    public GameObject spawnPoint;
    Vector3 spawnPos;
    public Quaternion rotation = Quaternion.Euler(0, -90, 0);

    //Unit Objects
    public GameObject zombiePrefab;
    public GameObject goblinPrefab;
    public GameObject abominationPrefab;
    public EnemyGoldMine goldMine;

    //Unit Prices
    int zombiePrice = 30;
    int goblinPrice = 25;
    int abominationPrice = 60;

    //HQ Properties
    public int lives = 10;
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        //get spawnpoint position
        spawnPos = spawnPoint.transform.position;
        
        //call RollForUnit reapeatedly
        InvokeRepeating("Decide", 5, 5);
    }

    public void loseLife(){
        lives--;
        livesText.text = lives.ToString();
        if(lives <= 0){
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
            case 4:
                //do nothing
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
        int rand = Random.Range(0, 4);
        Debug.Log("Enemy HQ Roll Value:\t" + rand);
        return rand;
    }

    void death(){
        CancelInvoke();
        SceneManager.LoadScene("YouWon");
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