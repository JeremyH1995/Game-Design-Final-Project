using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldMine : MonoBehaviour
{
    public Text goldtextBox;
    public Text levelTextBox;
    public Button btnGoldMine;
    public Text btnGoldMineText;
    int level = 1;
    const int MAX_LEVEL = 10;
    int gold = 0;    
    int upgradeCost = 25;

    // Start is called before the first frame update
    void Start()
    {
        btnGoldMine.onClick.AddListener(upgrade);
        InvokeRepeating("earnGold", 0, 1);
    }

    void earnGold(){
        gold += level;
        goldtextBox.text = gold.ToString();
    }

     public int getGold(){
        return gold;
    }
    public void buyUnit(int amount){
        gold -= amount;
    }


    void upgrade(){
        if(gold >= upgradeCost && level < MAX_LEVEL){
            gold -= upgradeCost;
            level++;
            upgradeCost *= 2;
            levelTextBox.text = "Level " + level.ToString();
            btnGoldMineText.text = "Upgrade Cost: " + upgradeCost.ToString();
        }
    }
}
