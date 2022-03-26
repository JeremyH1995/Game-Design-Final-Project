using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HQ : MonoBehaviour
{
    //Buttons
    public Button btnKnight;
    public Button btnZombie;
    //Spawn Info
    GameObject spawnPoint;
    public Vector3 spawnPos;
    public Quaternion rotation = Quaternion.Euler(0, 90, 0);

    //Unit Objects
    public GameObject knightPrefab;
    public GameObject zombiePrefab;

    //HQ Properties
    public int health = 1000;

    // Start is called before the first frame update
    void Start()
    {
        //get spawnpoint
        spawnPoint = GameObject.Find("SpawnPoint");
        spawnPos = spawnPoint.transform.position;
        //Create Listeners
        btnKnight.onClick.AddListener(spawnKnight);
        btnZombie.onClick.AddListener(spawnZombie);
        //assign controllers
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnKnight()
    {
        GameObject knight = Instantiate<GameObject>(knightPrefab, spawnPos, rotation);
    }

    void spawnZombie()
    {
        GameObject zombie = Instantiate<GameObject>(zombiePrefab, spawnPos, rotation);
    }
}