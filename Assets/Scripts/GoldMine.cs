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
    Vector3 goldMinePosition;
    Vector3 addPosition;
    int level = 1;
    const int MAX_LEVEL = 10;
    public int gold = 0;    
    int upgradeCost = 25;

    // Start is called before the first frame update
    void Start()
    {
        goldMinePosition = transform.position;
        addPosition = new Vector3(0f, 1f, 0f);
        btnUpgrade.gameObject.SetActive(false);
        btnUpgrade.onClick.AddListener(upgrade);
        InvokeRepeating("earnGold", 0, 1);
    }

    void onMouseOver(){
        if(!btnUpgrade.isActiveAndEnabled){
            btnUpgrade.transform.position = goldMinePosition + addPosition;
            btnUpgrade.gameObject.SetActive(true);
        }
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
            upgradeButtonText.text = "Upgrade Cost: " + upgradeCost.ToString();
        }
    }
}
