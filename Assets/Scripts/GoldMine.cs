using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldMine : MonoBehaviour
{
    public Text goldtextBox;
    public Text levelTextBox;
    public Button btnUpgrade;
    public Text upgradeButtonText;
    int level = 1;
    const int MAX_LEVEL = 10;
    public int gold = 0;    
    int upgradeCost = 25;

    // Start is called before the first frame update
    void Start()
    {
        btnUpgrade.onClick.AddListener(upgrade);
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
        goldtextBox.text = gold.ToString();
    }


    void upgrade(){
        if(gold >= upgradeCost && level < MAX_LEVEL){
            gold -= upgradeCost;
            level++;
            upgradeCost += 25;
            levelTextBox.text = "Level " + level.ToString();
             upgradeButtonText.text = "Upgrade Cost: " + upgradeCost.ToString();
            if(level == MAX_LEVEL){
                upgradeButtonText.text = "Max Level";
                btnUpgrade.interactable = false;
            }
        }
    }
}
