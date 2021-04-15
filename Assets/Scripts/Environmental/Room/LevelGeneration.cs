using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public float moveDistance = 20f;

    public GameObject testRoom;

    [SerializeField]
    private Vector3[] coordinates;
    private int spawnCounter;
    // Directions
    // 0 --> left
    // 1 --> top
    // 2 --> right
    // 3 --> down

    private void Awake() {
        coordinates[0] = Vector3.up * moveDistance;
        coordinates[1] = Vector3.right * moveDistance;
        coordinates[2] = Vector3.down * moveDistance;
        coordinates[3] = Vector3.left * moveDistance;

    }

    private void Start() {
        spawnCounter = 3;
        int rand = Random.Range(0, 1);

        Vector3 newPos = transform.position + coordinates[rand];
        Debug.Log(newPos);
        Instantiate(testRoom, newPos, Quaternion.identity);
    }


    private void Update() {
        
    }

    private void SpawnRoom() {
        int randSpawnAmount = Random.Range(spawnCounter-1, spawnCounter +1);
        if (randSpawnAmount == 3) {
            
        }
        int randSpawnLocation = Random.Range(0,3);

    }
}
