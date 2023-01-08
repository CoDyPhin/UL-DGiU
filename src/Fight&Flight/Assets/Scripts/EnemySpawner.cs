using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject movingEnemyPrefab;

    [SerializeField]
    private GameObject shootingEnemyPrefab;

    [SerializeField]
    private GameObject obstaclePrefab;

    [SerializeField]
    private GameObject warningPrefab;

    [SerializeField]
    private GameObject enemyHolder;

    [SerializeField]
    private int mEnemSpawnChance;
    
    [SerializeField]
    private int sEnemSpawnChance; // not implemented yet

    [SerializeField]
    private int obSpawnChance; // not implemented yet

    [SerializeField]
    private int warningSpawnChance; // not implemented yet

    [SerializeField]
    private float maxSpawnTimer = 5f;

    private bool genTimer = true;

    private float lastSpawnTime = 0f;

    private int totalSpawnChance;
    private float nextTime;

    [SerializeField]
    private GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        FixSpawnRates();
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(genTimer){
            nextTime = Random.Range(0f, maxSpawnTimer);
            lastSpawnTime = Time.time;
            genTimer = false;
        }
        else{
            if(Time.time - lastSpawnTime >= nextTime){
                DecideEnemy();
                genTimer = true;
            }
        }
    }

    void DecideEnemy()
    {
        int random = Random.Range(0, totalSpawnChance);
        Debug.Log(random);

        if(random < mEnemSpawnChance){
            SpawnMovingEnemy();
        }
        else if(random >= mEnemSpawnChance && random < sEnemSpawnChance){
            //SpawnEnemy(shootingEnemyPrefab);
        }
        else if(random >= sEnemSpawnChance && random < obSpawnChance){
            SpawnObstacle();
        }
        else if(random >= obSpawnChance && random < warningSpawnChance){
            //SpawnEnemy(warningPrefab);
        }
    }


    void SpawnMovingEnemy(){
        GameObject enemy = Instantiate(movingEnemyPrefab, new Vector3(transform.position.x, Random.Range(-2.2f, 4f), transform.position.z), Quaternion.identity);
        enemy.transform.parent = enemyHolder.transform;
    }

    void SpawnObstacle(){
        GameObject enemy = Instantiate(obstaclePrefab, new Vector3(15f, Random.Range(-2.2f, 4f), transform.position.z), Quaternion.identity);
        enemy.transform.parent = enemyHolder.transform;
        enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-background.GetComponent<CameraMovement>().GetSpeed(), 0f);
    }

    void FixSpawnRates(){
        totalSpawnChance = mEnemSpawnChance + sEnemSpawnChance + obSpawnChance + warningSpawnChance;
        sEnemSpawnChance = mEnemSpawnChance + sEnemSpawnChance;
        obSpawnChance = sEnemSpawnChance + obSpawnChance;
        warningSpawnChance = obSpawnChance + warningSpawnChance;
    }
}
