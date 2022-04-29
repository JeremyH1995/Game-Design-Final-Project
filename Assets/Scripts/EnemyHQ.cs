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

    //HQ Properties
    public int lives = 10;
    public Text livesText;

    //Units
    Zombie zombieUnit;
    Goblin goblinUnit;
    Abomination abominationUnit;


    // Start is called before the first frame update
    void Start()
    {
        //get spawnpoint position
        spawnPos = spawnPoint.transform.position;
        
        //call RollForUnit reapeatedly
        InvokeRepeating("Decide", 5, 5);

        //get units
        zombieUnit = zombiePrefab.GetComponent<Zombie>();
        goblinUnit = goblinPrefab.GetComponent<Goblin>();
        abominationUnit = abominationPrefab.GetComponent<Abomination>();
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
            case 1:
                spawnZombie();
                break;
            case 2:
            case 3: 
                spawnGoblin();
                break;
            case 4:
            case 5: 
                spawnAbomination();
                break;
            case 6:
            case 7:
            case 8:
            case 9: 
                goldMine.upgrade();
                break;
        }
    }
    
    int RollForUnit(){
        /*random number sheet 
        0 - 1: Zombie
        2 - 3: Goblin
        4 - 5: Abomination
         >= 6: upgrade Goldmine
        */
        int rand = Random.Range(0, 9);
        Debug.Log("Enemy HQ Roll Value:\t" + rand);
        return rand;
    }

    void death(){
        CancelInvoke();
        SceneManager.LoadScene("YouWon");
    }

    void spawnZombie()
    {
        if(goldMine.getGold() >= zombieUnit.cost){
            goldMine.buyUnit(zombieUnit.cost);
            GameObject zombie = Instantiate<GameObject>(zombiePrefab, spawnPos, rotation);
        }
            
    }

    void spawnAbomination(){
        if(goldMine.getGold() >= abominationUnit.cost){
            goldMine.buyUnit(abominationUnit.cost);
            GameObject abomination = Instantiate<GameObject>(abominationPrefab, spawnPos, rotation);
        }
            
    }

    void spawnGoblin(){
        if(goldMine.getGold() >= goblinUnit.cost){
            goldMine.buyUnit(goblinUnit.cost);
            GameObject goblin = Instantiate<GameObject>(goblinPrefab, spawnPos, rotation);
        }
    }
}