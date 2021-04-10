using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private Vector2 centerPos;

    public GameObject chunk;
    public GameObject smallChunk; // --> 0
    public GameObject[] interiorWalls; // --> 1
    public GameObject[] chunkTemplates; // --> 2
    public GameObject[] enemyTemplates;
    public int maxEnemies;
    public int minEnemies;


    public float minX;
    public float maxX;
    
    public float minY;
    public float maxY;

    public float chunkWidth;
    public float chunkHeight;

    public LayerMask whatIsRoom;

    


    private int largeChunkAmount;
    private int smallChunkAmount;
    private Vector2 randomPos;

    private int roomType;

    private void Start() {

        chunkWidth = 4;
        chunkHeight = 4;
        centerPos = transform.position;
        largeChunkAmount = Random.Range(1,3);
        smallChunkAmount = Random.Range(3,8);
        roomType = Random.Range(0,4);


        if(roomType == 0) {
            Invoke("SpawnLargeBlock", 0.1f);
        }
        else if(roomType == 1 || roomType == 3) {
            int rand = Random.Range(0,interiorWalls.Length);
            Instantiate(interiorWalls[rand], centerPos, Quaternion.identity);
            Invoke("SpawnEnemies", 0.5f);
        }
        else if(roomType == 2) {
            int rand = Random.Range(0, chunkTemplates.Length) ;
            Instantiate(chunkTemplates[rand], centerPos, Quaternion.identity);
            Invoke("SpawnEnemies", 0.5f);
            
        }

        Debug.Log(largeChunkAmount);
        

        

    }

    private void SpawnLargeBlock() {
        
        int randomX = (int)Random.Range(centerPos.x + minX, centerPos.x + maxX);
        int randomY = (int)Random.Range(centerPos.y + minY, centerPos.y + maxY);
        randomPos = new Vector2(randomX, randomY);
       

        Collider2D hit = Physics2D.OverlapBox(randomPos, new Vector2(chunkWidth, chunkHeight), 0, whatIsRoom);

        if (!hit) {
            Instantiate(chunk, randomPos, Quaternion.identity);
            largeChunkAmount--;
            if (largeChunkAmount > 0) {
                Invoke("SpawnLargeBlock", 0.1f);
            }
            else {
                Invoke("SpawnSmallBlock", 1);
            }
            return;
        }
        else {
            Invoke("SpawnLargeBlock", 0.1f);
            return;
        }
        
        
    }

    private void SpawnSmallBlock() {
        
        int randomX = (int)Random.Range(centerPos.x + minX, centerPos.x + maxX);
        int randomY = (int)Random.Range(centerPos.y + minY, centerPos.y + maxY);
        randomPos = new Vector2(randomX, randomY);
       

        Collider2D hit = Physics2D.OverlapBox(randomPos, new Vector2(chunkWidth, chunkHeight), 0, whatIsRoom);

        if (!hit) {
            Instantiate(smallChunk, randomPos, Quaternion.identity);
            smallChunkAmount--;
            if (smallChunkAmount > 0) {
                Invoke("SpawnSmallBlock", 0.1f);
            }
            else {
                SpawnEnemies();
            }
            return;
        }
        else {
            Invoke("SpawnSmallBlock", 0.1f);
            return;
        }
        
        
    }

    private void SpawnEnemies () {
        int randEnemiesAmount = Random.Range(minEnemies, maxEnemies);

        for (int i = 0; i < randEnemiesAmount; i++) {
            int rand = Random.Range(0, enemyTemplates.Length);
            int randomX = (int)Random.Range(centerPos.x + minX, centerPos.x + maxX);
            int randomY = (int)Random.Range(centerPos.y + minY, centerPos.y + maxY);
            randomPos = new Vector2(randomX, randomY);
            Debug.Log(randomPos);
       

            Collider2D hit = Physics2D.OverlapCircle(randomPos, 1f, whatIsRoom);
            if (!hit) {
                Instantiate(enemyTemplates[rand], randomPos, Quaternion.identity);
            }
            else {
                i--;
            }

        }
    }





}
