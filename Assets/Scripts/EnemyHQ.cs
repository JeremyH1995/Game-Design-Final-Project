using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHQ : MonoBehaviour
{
    //Buttons
    public Button btnZombie;
    //Spawn Info
    GameObject spawnPoint;
    public Vector3 spawnPos;
    public Quaternion rotation = Quaternion.Euler(0, -90, 0);

    //Unit Objects
    public GameObject zombiePrefab;

    //HQ Properties
    public int health = 1000;

    // Start is called before the first frame update
    void Start()
    {
        //get spawnpoint
        spawnPoint = GameObject.Find("EnemySpawnPoint");
        spawnPos = spawnPoint.transform.position;
        //Create Listeners
        btnZombie.onClick.AddListener(spawnZombie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnZombie()
    {
        GameObject zombie = Instantiate<GameObject>(zombiePrefab, spawnPos, rotation);
    }
}