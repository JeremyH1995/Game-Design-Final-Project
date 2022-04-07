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
    float elapsedTime;
    float timeLimit = 1f;
    int gold = 0;    
    int upgradeCost = 25;

    // Start is called before the first frame update
    void Start()
    {
        btnGoldMine.onClick.AddListener(upgrade);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= timeLimit){
            elapsedTime = 0;
            gold += level;
            goldtextBox.text = gold.ToString();
        }
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
