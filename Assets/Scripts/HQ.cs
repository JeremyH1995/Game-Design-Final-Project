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
    public GameObject WizardPrefab;

    //Unit Prices
    int knightPrice = 40;
    int archerPrice = 50;
    int wizardPrice = 100;
    //HQ Properties
    public int lives = 10;
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        //get spawn position
        spawnPos = spawnPoint.transform.position;
        //Create Listeners
        btnKnight.onClick.AddListener(spawnKnight);
        //btnArcher.onClick.AddListener(spawnArcher);
        //btnWizard.onClick.AddListener(spawnWizard);
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
        if(goldMine.getGold() > knightPrice){
            goldMine.buyUnit(knightPrice);
            GameObject knight = Instantiate<GameObject>(knightPrefab, spawnPos, rotation);
        }
    }

    void spawnArcher()
    {
        if(goldMine.getGold() > archerPrice){
            goldMine.buyUnit(archerPrice);
            GameObject knight = Instantiate<GameObject>(archerPrefab, spawnPos, rotation);
        }
    }

    void spawnWizard()
    {
        if(goldMine.getGold() > wizardPrice){
            goldMine.buyUnit(wizardPrice);
            GameObject knight = Instantiate<GameObject>(WizardPrefab, spawnPos, rotation);
        }
    }
}