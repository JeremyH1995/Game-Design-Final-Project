using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGoldMine : MonoBehaviour
{
    public Text enemyGold;
    public Text enemyLevel;
    int level = 1;
    const int MAX_LEVEL = 10;
    int gold = 0;    
    int upgradeCost = 25;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("earnGold", 0, 1);
    }

    void earnGold(){
        gold += level;
        enemyGold.text = gold.ToString();
    }

    public int getGold(){
        return gold;
    }
    public void buyUnit(int amount){
        gold -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgrade(){
        if(gold >= upgradeCost && level < MAX_LEVEL){
            gold -= upgradeCost;
            level++;
            upgradeCost *= 2;
            enemyLevel.text = level.ToString();
        }
    }
}
