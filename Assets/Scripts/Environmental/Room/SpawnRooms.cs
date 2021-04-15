// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SpawnRooms : MonoBehaviour
// {
//     public LayerMask whatIsRoom;
//     public LevelGeneration levelGen;
//     public CheckRoom checkRoom;
//     private bool added;

//     public GameObject[] rooms;
//     private void Update() {
//         // Check if current pose got room, if no run algorithm to spawn room with probability
//         if(!added) {
//             Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
//             if(roomDetection == null && levelGen.stopGeneration2) {

//                 // int rand = Random.Range(0, levelGen.rooms.Length);
//                 // Instantiate(rooms[rand], transform.position, Quaternion.identity);

//                 checkRoom.emptyRoomPoses.Add(gameObject);
//                 added = true;
//                 //Destroy(gameObject);
//             }
//         }
//     }

//     public void SpawnRoom(int spawnType) {
//         int rand = Random.Range(0, levelGen.rooms.Length);

//         if(spawnType == 1) {
//             //TOP
//             // Instantiate(rooms[0], transform.position, Quaternion.identity);
//             // Collider2D detectedRoom = Physics2D.OverlapCircle(transform.position + Vector3.up * 20, whatIsRoom);
//             // if(detectedRoom.GetComponent<RoomType>().type == 1) {
//             //     Instantiate(rooms[2], transform.position + Vector3.up * 20, Quaternion.Euler(0,0,-180));
//             // }
//             // else if(detectedRoom.GetComponent<RoomType>().type == 2 && detectedRoom.transform.rotation.z == 0) {
//             //     Instantiate(rooms[2], transform.position + Vector3.up * 20, Quaternion.Euler(0,0,-90));
//             // }
//             // else if(detectedRoom.GetComponent<RoomType>().type == 2 && detectedRoom.transform.rotation.z == -270) {
//             //     Instantiate(rooms[2], transform.position + Vector3.up * 20, Quaternion.Euler(0,0,-270));
//             // }
//             // /Destroy(detectedRoom.gameObject);
//         }
//         else if (spawnType == 2) {
//             //RIGHT
//             Instantiate(rooms[0], transform.position, Quaternion.Euler(0,0,-90f));

//             // Collider2D detectedRoom = Physics2D.OverlapCircle(transform.position + Vector3.right * 20, whatIsRoom);
//             // if(detectedRoom.GetComponent<RoomType>().type == 1) {
//             //     Instantiate(rooms[2], transform.position+ Vector3.right * 20, Quaternion.Euler(0,0,-270));
//             // }
//             // else if(detectedRoom.GetComponent<RoomType>().type == 2 && detectedRoom.transform.rotation.z == 0) {
//             //     Instantiate(rooms[2], transform.position+ Vector3.right * 20, Quaternion.Euler(0,0,0));
//             // }
//             // else if(detectedRoom.GetComponent<RoomType>().type == 2 && detectedRoom.transform.rotation.z == -90) {
//             //     Instantiate(rooms[2], transform.position+ Vector3.right * 20, Quaternion.Euler(0,0,-180));
//             // }
//             // Destroy(detectedRoom.gameObject);

//         }
//         else if (spawnType == 3){
//             //BOTTOM
//             Instantiate(rooms[0], transform.position, Quaternion.Euler(0,0,-180f));

//             // Collider2D detectedRoom = Physics2D.OverlapCircle(transform.position + Vector3.down * 20, whatIsRoom);
//             // if(detectedRoom.GetComponent<RoomType>().type == 1) {
//             //     Instantiate(rooms[2], transform.position + Vector3.down * 20, Quaternion.Euler(0,0,0));
//             // }
//             // else if(detectedRoom.GetComponent<RoomType>().type == 2 && detectedRoom.transform.rotation.z == -90) {
//             //     Instantiate(rooms[2], transform.position + Vector3.down * 20, Quaternion.Euler(0,0,-90));
//             // }
//             // else if(detectedRoom.GetComponent<RoomType>().type == 2 && detectedRoom.transform.rotation.z == -180) {
//             //     Instantiate(rooms[2], transform.position + Vector3.down * 20, Quaternion.Euler(0,0,-270));
//             // }
//             // Destroy(detectedRoom.gameObject);

//         }
//         else if (spawnType == 4){
//             //LEFT
//             Instantiate(rooms[0], transform.position, Quaternion.Euler(0,0,-270f));

//             // Collider2D detectedRoom = Physics2D.OverlapCircle(transform.position + Vector3.left * 20, whatIsRoom);
//             // if(detectedRoom.GetComponent<RoomType>().type == 1) {
//             //     Instantiate(rooms[2], transform.position + Vector3.left * 20, Quaternion.Euler(0,0,-90));
//             // }
//             // else if(detectedRoom.GetComponent<RoomType>().type == 2 && detectedRoom.transform.rotation.z == -180) {
//             //     Instantiate(rooms[2], transform.position + Vector3.left * 20, Quaternion.Euler(0,0,-180));
//             // }
//             // else if(detectedRoom.GetComponent<RoomType>().type == 2 && detectedRoom.transform.rotation.z == -270) {
//             //     Instantiate(rooms[2], transform.position + Vector3.left * 20, Quaternion.Euler(0,0,0));
//             // }
//             // Destroy(detectedRoom.gameObject);

//         }
//         Destroy(gameObject);
//     }
// }
