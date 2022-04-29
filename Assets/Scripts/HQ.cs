using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HQ : MonoBehaviour
{
    //Buttons
    public Button btnKnight;
    public Button btnArcher;
    public Button btnWizard;
    //Spawn Info
    public GameObject spawnPoint;
    Vector3 spawnPos;
    public Quaternion rotation = Quaternion.Euler(0, 90, 0);

    //Unit Objects
    public GoldMine goldMine;
    public GameObject knightPrefab;
    public GameObject archerPrefab;
    public GameObject wizardPrefab;

    //HQ Properties
    public int lives = 10;
    public Text livesText;

    //Units
    Knight knightUnit;
    Archer archerUnit;
    Wizard wizardUnit;


    // Start is called before the first frame update
    void Start()
    {
        //get spawn position
        spawnPos = spawnPoint.transform.position;
        //Create Listeners
        btnKnight.onClick.AddListener(spawnKnight);
        btnArcher.onClick.AddListener(spawnArcher);
        btnWizard.onClick.AddListener(spawnWizard);
        //get units
        knightUnit = knightPrefab.GetComponent<Knight>();
        archerUnit = archerPrefab.GetComponent<Archer>();
        wizardUnit = wizardPrefab.GetComponent<Wizard>();
    }

    public void loseLife(){
        lives--;
        livesText.text = lives.ToString();
        if(lives <= 0){
            death();
        }
    }

    void death(){
        CancelInvoke();
        SceneManager.LoadScene("YouLost");
    }


    void spawnKnight()
    {
        if(goldMine.getGold() >= knightUnit.cost){
            goldMine.buyUnit(knightUnit.cost);
            GameObject knight = Instantiate<GameObject>(knightPrefab, spawnPos, rotation);
        }
    }

    void spawnArcher()
    {
        if(goldMine.getGold() >= archerUnit.cost){
            goldMine.buyUnit(archerUnit.cost);
            GameObject knight = Instantiate<GameObject>(archerPrefab, spawnPos, rotation);
        }
    }

    void spawnWizard()
    {
        if(goldMine.getGold() >= wizardUnit.cost){
            goldMine.buyUnit(wizardUnit.cost);
            GameObject knight = Instantiate<GameObject>(wizardPrefab, spawnPos, rotation);
        }
    }
}