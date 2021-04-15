using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public bool entered = false;
    public bool entering = false;
    public float sideDistance = 14f;
    public float verticalDistance = 9f;

    public int maxEnemyWaves = 1;

    private Vector3 roomSize;
    private Vector2 startPos;
    private Vector2 endPos;
    private EnemySpawner enemySpawner;

    public LayerMask whatIsPlayer;
    private Transform doors;
    private float lastCheckTime = -10f;

    private void Awake() {
        whatIsPlayer += LayerMask.GetMask("Player");
    }

    private void Start() {
        roomSize = new Vector3(sideDistance, verticalDistance, 0);

        startPos = new Vector2(transform.position.x - sideDistance, transform.position.y - verticalDistance);
        endPos = new Vector2(transform.position.x + sideDistance, transform.position.y + verticalDistance);

        doors = gameObject.transform.Find("Doors");
        enemySpawner = GetComponent<EnemySpawner>();
        maxEnemyWaves = 2;
    }

    private void Update() {
        if(!entered) {
            Collider2D playerDetected = Physics2D.OverlapArea(startPos, endPos, whatIsPlayer);
            if (playerDetected) {
                Debug.Log("Close Door!");
                entered = true;
                entering = true;
                doors.SendMessage("CloseDoor");                
                if(maxEnemyWaves > 0 ){

                    enemySpawner.SpawnEnemies();
                    maxEnemyWaves--;
                }
            }

        }

        //Debug.Log("Enemies Num: " + enemySpawner.enemies.Count);
        if(entering) {
            if (lastCheckTime + 0.5f < Time.time) {
                lastCheckTime = Time.time;
                if (enemySpawner.enemiesHolder.transform.childCount == 0) {
                    if (maxEnemyWaves > 0) {
                        enemySpawner.SpawnEnemies();
                        maxEnemyWaves--;
                    }
                    else {
                        doors.SendMessage("OpenDoor");
                        entering = false;
                    }
                }
            }
        }   
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, roomSize*2);
    }


}
