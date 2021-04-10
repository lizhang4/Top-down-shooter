using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    public LayerMask whatIsRoom;
    public int layer = 2;

    // 1 --> need top door
    // 2 --> need right door
    // 3 --> need bottom door
    // 4 --> need left door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    public float waitTime = 8f;

    private void Start() {


        waitTime = 8f;
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        //Debug.Log(transform.parent.parent.eulerAngles.z);

        Invoke("Spawn", 0.5f);
    }


    private void Spawn() {
        
        

        if(spawned == false && layer >= 1) {
            if(openingDirection == 1) {
                // need room with bottom door
    
                if (layer == 1) {
                    rand = 0;
                }
                else if (layer == 2) {
                    rand = Random.Range(0,2);
                }
                else {
                    rand = Random.Range(0, 4);
                }
                //Debug.Log(templates.bottomRooms[rand].transform.eulerAngles);
                //int randRotation = Random.Range(0, templates.rooms[rand].GetComponent<RoomType>().bottomDoorRotation.Length);
                float bottomRotation = templates.bottomRooms[rand].transform.eulerAngles.z;
                
                GameObject tempObj = Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.Euler(0,0,bottomRotation));
                RoomSpawner[] roomSpawnerComponents = tempObj.GetComponentsInChildren<RoomSpawner>();

                foreach (RoomSpawner roomSpawnerComponent in roomSpawnerComponents) {
                    roomSpawnerComponent.layer = layer-1;
                }

                
            } 
            else if (openingDirection == 2) {
                // need room with left door
                if (layer == 1) {
                    rand = 0;
                }
                else if (layer == 2) {
                    rand = Random.Range(0,2);
                }
                else {
                    rand = Random.Range(0, 4);

                }
                
                float leftRotation = templates.leftRooms[rand].transform.eulerAngles.z;
                GameObject tempObj = Instantiate(templates.leftRooms[rand], transform.position, Quaternion.Euler(0,0,leftRotation));
                RoomSpawner[] roomSpawnerComponents = tempObj.GetComponentsInChildren<RoomSpawner>();

                foreach (RoomSpawner roomSpawnerComponent in roomSpawnerComponents) {
                    roomSpawnerComponent.layer = layer-1;

                }



            } 
            else if (openingDirection == 3) {
                // need room with top door

                if (layer == 1) {
                    rand = 0;
                }
                else if (layer == 2) {
                    rand = Random.Range(0,2);
                }
                else {
                    rand = Random.Range(0, 4);
                }

                
                float topRotation = templates.topRooms[rand].transform.eulerAngles.z;
                GameObject tempObj = Instantiate(templates.topRooms[rand], transform.position, Quaternion.Euler(0,0,topRotation));
                RoomSpawner[] roomSpawnerComponents = tempObj.GetComponentsInChildren<RoomSpawner>();

                foreach (RoomSpawner roomSpawnerComponent in roomSpawnerComponents) {
                    roomSpawnerComponent.layer = layer-1;

                }



            } 
            else if (openingDirection == 4) {
                // need room with right door

                if (layer == 1) {
                    rand = 0;
                }
                else if (layer == 2) {
                    rand = Random.Range(0,2);
                }
                else {
                    rand = Random.Range(0, 4);
                }



                float rightRotation = templates.rightRooms[rand].transform.eulerAngles.z;
                GameObject tempObj = Instantiate(templates.rightRooms[rand], transform.position, Quaternion.Euler(0,0,rightRotation));
                RoomSpawner[] roomSpawnerComponents = tempObj.GetComponentsInChildren<RoomSpawner>();

                foreach (RoomSpawner roomSpawnerComponent in roomSpawnerComponents) {
                    roomSpawnerComponent.layer = layer-1;

                }


            }
            spawned = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("SpawnPoint")){
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
                Collider2D detected = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom );
               
                // Debug.Log(detected.gameObject.name);
                if (!detected) {
                    //GameObject tempObj = Instantiate(templates.rooms[2], transform.position, Quaternion.identity);
                    Debug.Log("Add connecting room");
                    templates.connectionRoomPos.Add(transform.position);
                }
                // if (detected) {
                //     Debug.Log("Destroy");
                //     Destroy(tempObj);
                // }
                // else {
                //     Debug.Log("Spawn");
                // }
                //Destroy(gameObject);
            }
                // spawn walls to block openings
                // spawn room 2 

                //GameObject tempObj = Instantiate(templates.rooms[2], transform.position, Quaternion.identity);

                
            
            spawned = true;
        }
    }

    private void SpawnConnectedRoom(Vector3 position) {
        Instantiate(templates.rooms[2], position, Quaternion.identity);
    }




}
