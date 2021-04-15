using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyTemplates;
    public GameObject spawnLocator;
    public int maxEnemies;
    public int minEnemies;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public Vector2 centerPos;
    public LayerMask whatIsObstacles;

    public int enemyCounter;

    public GameObject enemiesHolder;

    private RoomGenerator roomGenerator;
    private RoomController roomController;
    private int rand;
    private int randomX;
    private int randomY;
    private Vector2 randomPos;

    private void Awake() {
        whatIsObstacles += LayerMask.GetMask("Room");
        whatIsObstacles += LayerMask.GetMask("Wall");
        whatIsObstacles += LayerMask.GetMask("Destructible");
        whatIsObstacles += LayerMask.GetMask("Player");


    }

    private void Start() {


        minX = -12;
        maxX = 12;
        minY = -8;
        maxY = 8;
        maxEnemies = 10;
        minEnemies = 6;

        centerPos = transform.position;

        enemiesHolder = GameObject.FindGameObjectWithTag("EnemiesHolder");
    }


    public void SpawnEnemies () {
        int randEnemiesAmount = Random.Range(minEnemies, maxEnemies);
        enemyCounter = 0;
        for (int i = 0; i < randEnemiesAmount; i++) {
            rand = Random.Range(0, enemyTemplates.Length);
            randomX = (int)Random.Range(transform.position.x + minX, transform.position.x + maxX);
            randomY = (int)Random.Range(transform.position.y + minY, transform.position.y + maxY);
            randomPos = new Vector2(randomX, randomY);
            Debug.Log(randomPos);
       

            Collider2D hit = Physics2D.OverlapCircle(randomPos, 1f, whatIsObstacles);
            if (!hit) {
                GameObject tempSpawnLocator = Instantiate(spawnLocator, randomPos, Quaternion.identity);
                GameObject tempEnemy = Instantiate(enemyTemplates[rand], randomPos, Quaternion.identity);
                tempEnemy.SetActive(false);
                tempEnemy.transform.SetParent(enemiesHolder.transform);
                StartCoroutine(Spawn(rand, randomPos, tempSpawnLocator, tempEnemy));
                //enemies.Add(tempEnemy);
                
            }
            else {
                i--;
            }

        }
    }

    

    public IEnumerator Spawn(int rand, Vector2 randomPos, GameObject tempSpawnLocator, GameObject tempEnemy) {

        yield return new WaitForSeconds(1f);
        Destroy(tempSpawnLocator);
        tempEnemy.SetActive(true);
        
    }
}
